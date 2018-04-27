package com.augmentum.service.impl;

import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

import com.augmentum.Constants;
import com.augmentum.dao.QuestionDao;
import com.augmentum.dao.impl.QuestionDaoImpl;
import com.augmentum.exception.ParamException;
import com.augmentum.exception.ServiceException;
import com.augmentum.model.Question;
import com.augmentum.service.QuestionService;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.MessageUtil;
import com.augmentum.util.StringUtil;

public class QuestionServiceImpl implements QuestionService {

    private QuestionDao questionDao;

    public void setQuestionDao(QuestionDaoImpl questionDaoImpl) {
        this.questionDao = questionDaoImpl;
    }

    @Override
    public void addQuestion(Question question) {

        validateData(question);

        question.setNum("");
        long key = questionDao.addQuestion(question);

        question.setId(Integer.parseInt(String.valueOf(key)));
        question.setNum("Q000"+key);

        if (!questionDao.editQuestion(question)) {
            throw new ServiceException(MessageUtil.ENTITY_CREATE_FAILED,
                    MessageUtil.buildMessage(MessageUtil.ENTITY_CREATE_FAILED,
                            MessageUtil.ENTITY_QUESTION));
        }

    }

    @Override
    public void editQuestion(Question question) {

        validateData(question);

        // 修改题目
        // 1.查询当前问题是否已被删除过 即 当前问题的delmark是否是0
        Question questionQuery = questionDao.getQuestion(question);

        if (questionQuery == null) {
            throw new ServiceException(MessageUtil.ENTITY_DELETE_ALREADY,
                    MessageUtil.buildMessage(MessageUtil.ENTITY_DELETE_ALREADY,
                            MessageUtil.ENTITY_QUESTION));
        }


        boolean isExist = questionQuery.getReferMark() == Constants.STATUS_ONE ? true : false;

        if (!isExist) {
        // 2.如果没有被用过，直接修改自己
            if (!questionDao.editQuestion(question)) {
                throw new ServiceException(MessageUtil.ENTITY_UPDATE_FAILED,
                        MessageUtil.buildMessage(MessageUtil.ENTITY_UPDATE_FAILED,
                                MessageUtil.ENTITY_QUESTION));
            }
        } else {
        // 3.被用过，就修改当前delMark =1，然后添加一条新的记录
            Object[][] obj = new Object[1][1];
            obj[0][0] = question.getId().intValue();
            int size = questionDao.deleteQuestion(obj);

            if (size == Constants.STATUS_ZERO) {
                throw new ServiceException(MessageUtil.ENTITY_UPDATE_FAILED,
                        MessageUtil.buildMessage(MessageUtil.ENTITY_UPDATE_FAILED,
                                MessageUtil.ENTITY_QUESTION));
            }

            questionDao.addQuestion(question);

        }

    }

    @Override
    public void deleteQuestion(String[] idArr) {

        if (idArr == null) {
            throw new ParamException(MessageUtil.DATA_NOSELECTED_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DATA_NOSELECTED_ERROR,
                            MessageUtil.ENTITY_QUESTION));
        }

        Object[][] objArr = new Object[idArr.length][1];

        for (int i = 0; i < objArr.length; i++) {
            objArr[i][0]=idArr[i];
        }

        int size = questionDao.deleteQuestion(objArr);

        if (idArr.length > size) {
            throw new ServiceException(MessageUtil.DATA_PART_DELETE,
                    MessageUtil.buildMessage(MessageUtil.DATA_PART_DELETE,
                            idArr.length, size));
        }
    }

    @Override
    public Question getQuestion(Question question) {
        // Pass 1:validate question
        if (question == null || question.getId() == Constants.STATUS_ZERO) {
            throw new ParamException(MessageUtil.DATA_VALIDATE_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DATA_VALIDATE_ERROR));
        }

        question = questionDao.getQuestion(question);

        if (question == null) {
            throw new ServiceException(MessageUtil.ENTITY_NOT_FOUND,
                    MessageUtil.buildMessage(MessageUtil.ENTITY_NOT_FOUND,
                            MessageUtil.ENTITY_QUESTION));
        }

        return question;
    }

    @Override
    public FuzzyCriterion<Question> findQuestionList(FuzzyCriterion<Question> fuzzyCriterion) {
        fuzzyCriterion.getPage().setTotalItem(questionDao.getQuestionCount(fuzzyCriterion));

        fuzzyCriterion.getPage().setPageList(questionDao.findQuestion(fuzzyCriterion));

        return fuzzyCriterion;

    }

    private void validateData(Question question) {
        Map<String, String> errMsgMap = new ConcurrentHashMap<>();
        /*
         * Validate the data according the rules below:
         * 2.title can not be empty
         * 3.item A-D can not be empty
         * 4.answer can not equals to 0
         */
        validateData(errMsgMap, question.getTitle(), MessageUtil.ENTITY_QUESTION_TITLE);
        validateData(errMsgMap, question.getItemA(), MessageUtil.ENTITY_QUESTION_ITEMA);
        validateData(errMsgMap, question.getItemB(), MessageUtil.ENTITY_QUESTION_ITEMB);
        validateData(errMsgMap, question.getItemC(), MessageUtil.ENTITY_QUESTION_ITEMC);
        validateData(errMsgMap, question.getItemD(), MessageUtil.ENTITY_QUESTION_ITEMD);
        if (Constants.STATUS_ZERO == question.getAnswer()) {
            errMsgMap.put(MessageUtil.ENTITY_QUESTION_ANSWER,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR,
                            MessageUtil.ENTITY_QUESTION_ANSWER, MessageUtil.ENTITY_QUESTION));
        }

        if (!errMsgMap.isEmpty()) {
            throw new ParamException(MessageUtil.DATA_VALIDATE_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DATA_VALIDATE_ERROR),
                    errMsgMap);
        }
    }

    private void validateData(Map<String, String> errMsgMap, String fieldVal, String fieldName) {
        if (StringUtil.isEmpty(fieldVal)) {
            errMsgMap.put(fieldName,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR, fieldName, MessageUtil.ENTITY_QUESTION));
        }
    }

}
