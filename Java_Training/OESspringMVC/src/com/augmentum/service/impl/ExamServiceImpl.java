package com.augmentum.service.impl;

import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

import com.augmentum.Constants;
import com.augmentum.dao.ExamDao;
import com.augmentum.dao.QuestionDao;
import com.augmentum.exception.ParamException;
import com.augmentum.exception.ServiceException;
import com.augmentum.model.Exam;
import com.augmentum.model.Question;
import com.augmentum.service.ExamService;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.MessageUtil;
import com.augmentum.util.StringUtil;

public class ExamServiceImpl implements ExamService {

    private ExamDao examDao;
    private QuestionDao questionDao;

    public void setExamDao(ExamDao examDao) {
        this.examDao = examDao;
    }

    public void setQuestionDao(QuestionDao questionDao) {
        this.questionDao = questionDao;
    }

    /**
     * Transcation
     * Add Exam by get question randomly.
     * 1.if current question bank's stock is no more than the question user needed,
     *   save this exam as a draft.(modify status to 0)
     * 2.if the question user needed is enough, add Exam.(modify status to 1)
     * 3.Put relations between question and exam into exam_question.
     * @param exam
     */
    @Override
    public void addExam(Exam exam, boolean saveFlag) {
        Map<String, String> errMsgMap = new ConcurrentHashMap<>();
        if (StringUtil.isEmpty(exam.getName())) {
            errMsgMap.put(Exam.NAME,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR,
                            Exam.NAME, Exam.EXAM));
        } else if (exam.getName().length() >=32) {
            errMsgMap.put(Exam.NAME,
                    MessageUtil.buildMessage(MessageUtil.DATA_TOO_LONG,
                            Exam.NAME));
        }
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm");
        try {
            format.setLenient(false);
            format.parse(exam.getEffectiveTime());
        } catch (Exception e) {
            errMsgMap.put(Exam.EFFECTIVE_TIME,
                    MessageUtil.buildMessage(MessageUtil.TIME_FORMAT_ERROR,
                            Exam.EFFECTIVE_TIME, Exam.EXAM));
        }

        validateData(errMsgMap, exam.getDuration(), Exam.DURATION);
        validateData(errMsgMap, exam.getNeedQuantity(), Exam.NEED_QUANTITY);
        validateData(errMsgMap, exam.getPassCriteria(), Exam.PASS_CRITERIA);
        validateData(errMsgMap, exam.getSingleScore(), Exam.SINGLE_SCORE);
        validateData(errMsgMap, exam.getTotalScore(), Exam.TOTAL_SCORE);

        if (!errMsgMap.isEmpty()) {
            throw new ParamException(MessageUtil.DATA_VALIDATE_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DATA_VALIDATE_ERROR),
                    errMsgMap);
        }

        /**
         * Pass 1: Get total count of question bank.
         * Pass 2: if it is not enough for us, then pop up a message whether save it
         * */
        int countInBank = questionDao.getQuestionCount(null);
        if (countInBank < exam.getNeedQuantity()) {
            if (!saveFlag) {
                // Save as draft
                throw new ServiceException(MessageUtil.SAVE_AS_DRAFT,
                        MessageUtil.buildMessage(MessageUtil.SAVE_AS_DRAFT));
            }
        }

        // Pass 3: Pick enough question by random
        List<Question> questionList = questionDao.findQuestionIdList(exam);

        // Pass 4: Modify question "refer_mark" 1
        Object[][] objList = new Object[questionList.size()][1];
        for (int i = 0; i < questionList.size(); i++) {
            objList[i][0] = questionList.get(i).getId();
        }

        questionDao.batchEditQuestion(objList);

        // Pass 5: Add question to bank, return generate key and modify question num
        //         Set exam string
        StringBuilder answer = new StringBuilder();
        for (int i = 0; i < questionList.size(); i++) {
            answer.append((i + 1) + "," + questionList.get(i).getAnswer() + "&");
        }
        exam.setAnswerStr(answer.substring(Constants.STATUS_ZERO, answer.lastIndexOf("&")).toString());

        if (questionList.size() == exam.getNeedQuantity()) {
            exam.setFactQuantity(exam.getNeedQuantity());
        } else {
            exam.setFactQuantity(questionList.size());
        }

        exam.setStatus(saveFlag ? Constants.STATUS_ZERO : Constants.STATUS_ONE);

        Long key = examDao.addExam(exam);

        exam.setNum("E0000" + key.intValue());

        examDao.editExam(exam);

        // Pass 6: Add mapping between question and answer to database

        examDao.batchInsertQuestionToPaper(exam, objList);

    }

    @Override
    public FuzzyCriterion<Exam> findExamList(FuzzyCriterion<Exam> fuzzyCriterion) {

        fuzzyCriterion.getPage().setTotalItem(examDao.getExamCount(fuzzyCriterion));

        fuzzyCriterion.getPage().setPageList(examDao.findExamList(fuzzyCriterion));

        return fuzzyCriterion;

    }

    private void validateData(Map<String, String> errMsgMap, float fieldVal, String fieldName) {
        if (fieldVal == 0.0f) {
            errMsgMap.put(fieldName,
                    MessageUtil.buildMessage(MessageUtil.NUMBERIC_FIELD_ERROR, fieldName, Exam.EXAM));
        }
    }

}
