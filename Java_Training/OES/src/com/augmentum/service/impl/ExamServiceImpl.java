package com.augmentum.service.impl;

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
            errMsgMap.put(MessageUtil.ENTITY_EXAM_NAME,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR,
                            MessageUtil.ENTITY_EXAM_NAME, MessageUtil.ENTITY_EXAM));
        }
        // effectiveTime reg
//        if (!exam.getEffectiveTime().matches("/^((?:19|20)\\d\\d)-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01]) (0\\d{1}|1\\d{1}|2[0-3]):([0-5]\\d{1})$/")) {
//            errMsgMap.put(MessageUtil.ENTITY_EXAM_EFFECTIVETIME,
//                    MessageUtil.buildMessage(MessageUtil.TIME_FORMAT_ERROR,
//                            MessageUtil.ENTITY_EXAM_EFFECTIVETIME, MessageUtil.ENTITY_EXAM));
//        }

        validateData(errMsgMap, exam.getDuration(), MessageUtil.ENTITY_EXAM_DURATION);
        validateData(errMsgMap, exam.getNeedQuantity(), MessageUtil.ENTITY_EXAM_NEEDQUANTITY);
        validateData(errMsgMap, exam.getPassCriteria(), MessageUtil.ENTITY_EXAM_PASSCRITERIA);
        validateData(errMsgMap, exam.getSingleScore(), MessageUtil.ENTITY_EXAM_SINGLESCORE);
        validateData(errMsgMap, exam.getTotalScore(), MessageUtil.ENTITY_EXAM_TOTALSCORE);

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

        int editItem = questionDao.batchEditQuestion(objList);
        if (objList.length != editItem) {
            throw new ServiceException(MessageUtil.ENTITY_CREATE_FAILED,
                    MessageUtil.buildMessage(MessageUtil.ENTITY_CREATE_FAILED,
                            Constants.EXAM));
        }

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

        long key = examDao.addExam(exam);

        exam.setNum("E0000"+key);
        exam.setId(Integer.parseInt(String.valueOf(key)));
        boolean flag = examDao.editExam(exam);

        if (!flag) {
            throw new ServiceException(MessageUtil.ENTITY_CREATE_FAILED,
                    MessageUtil.buildMessage(MessageUtil.ENTITY_CREATE_FAILED,
                            Constants.EXAM));
        }
        // Pass 6: Add mapping between question and answer to database

        int affectRows = examDao.batchInsertQuestionToPaper(exam, objList);

        if (affectRows != exam.getFactQuantity()) {
            throw new ServiceException(MessageUtil.ENTITY_CREATE_FAILED,
                    MessageUtil.buildMessage(MessageUtil.ENTITY_CREATE_FAILED,
                            Constants.EXAM));
        }
    }

    @Override
    public FuzzyCriterion<Exam> findExamList(FuzzyCriterion<Exam> fuzzyCriterion) {

        // 获取满足条件的考试总数量
        fuzzyCriterion.getPage().setTotalItem(examDao.getExamCount(fuzzyCriterion));

        // 获取满足条件的考试列表
        fuzzyCriterion.getPage().setPageList(examDao.findExamList(fuzzyCriterion));

        return fuzzyCriterion;

    }

    private void validateData(Map<String, String> errMsgMap, float fieldVal, String fieldName) {
        if (fieldVal == 0.0f) {
            errMsgMap.put(fieldName,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR, fieldName, MessageUtil.ENTITY_EXAM));
        }
    }

}
