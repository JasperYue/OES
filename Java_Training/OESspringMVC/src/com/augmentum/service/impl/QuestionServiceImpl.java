package com.augmentum.service.impl;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

import com.augmentum.Constants;
import com.augmentum.dao.QuestionDao;
import com.augmentum.exception.ParamException;
import com.augmentum.exception.ServiceException;
import com.augmentum.model.Question;
import com.augmentum.service.QuestionService;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.MessageUtil;
import com.augmentum.util.StringUtil;

public class QuestionServiceImpl implements QuestionService {

    private QuestionDao questionDao;

    public void setQuestionDao(QuestionDao questionDao) {
        this.questionDao = questionDao;
    }

    @Override
    public void addQuestion(Question question) {

        validateData(question);

        question.setNum(Constants.NO_CONTENTS);

        Long key = questionDao.addQuestion(question);
        question.setNum("Q000" + key.intValue());

        questionDao.editQuestion(question);

    }

    @Override
    public void editQuestion(Question question) {

        validateData(question);

        // Pass 1: Query current question whether is already deleted.
        //         delmark = 1 already deleted
        Question questionQuery = questionDao.getQuestion(question);

        if (questionQuery == null) {
            throw new ServiceException(MessageUtil.ENTITY_DELETE_ALREADY,
                    MessageUtil.buildMessage(MessageUtil.ENTITY_DELETE_ALREADY,
                            Question.QUESTION));
        }

        // Pass 2: Whether current question referred by exam
        boolean isExist = questionQuery.getReferMark() == Constants.STATUS_ONE ? true : false;

        if (!isExist) {
            // Pass 2.1: if not referred by exam, modify this question directly.
            questionDao.editQuestion(question);
        } else {
            // Pass 2.2: if referred by exam, modify this question delmark to 1
            //           Then add a new record all the same.
            Object[][] obj = new Object[1][1];
            obj[0][0] = question.getId().intValue();
            questionDao.deleteQuestion(obj);
            questionDao.addQuestion(question);
        }

    }

    @Override
    public void deleteQuestion(String[] idArr) {

        if (idArr == null) {
            throw new ParamException(MessageUtil.DATA_NOSELECTED_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DATA_NOSELECTED_ERROR,
                            Question.QUESTION));
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
                            Question.QUESTION));
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
         * 4.length can not exceed 256
         * 5.item can not be repeat
         */
        validateData(errMsgMap, question.getTitle(), Question.TITLE);
        validateData(errMsgMap, question.getItemA(), Question.ITEM_A);
        validateData(errMsgMap, question.getItemB(), Question.ITEM_B);
        validateData(errMsgMap, question.getItemC(), Question.ITEM_C);
        validateData(errMsgMap, question.getItemD(), Question.ITEM_D);

        Map<String, String> itemMap = new HashMap<>();
        itemMap.put(question.getItemA(), Question.ITEM_A);
        itemMap.put(question.getItemB(), Question.ITEM_B);
        itemMap.put(question.getItemC(), Question.ITEM_C);
        itemMap.put(question.getItemD(), Question.ITEM_D);

        if (itemMap.size() < 4) {
            String[] itemArr = {Question.ITEM_A, Question.ITEM_B, Question.ITEM_C, Question.ITEM_D};
            for (int i = 0; i < itemArr.length; i++) {
                Collection<String> itemCollection = itemMap.values();
                boolean flag = false;
                for (String str : itemCollection) {
                    if (StringUtil.isEquals(itemArr[i], str)) {
                        flag = true;
                    }
                }
                if (!flag) {
                    if (errMsgMap.get(itemArr[i]) == null) {
                        errMsgMap.put(itemArr[i],
                                MessageUtil.buildMessage(MessageUtil.ITEM_REPEAT));
                    }
                }
            }
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
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR, fieldName, Question.QUESTION));
            return;
        } else if (fieldVal.length() >= 256) {
            errMsgMap.put(fieldName,
                    MessageUtil.buildMessage(MessageUtil.DATA_TOO_LONG, fieldName));
        }
    }

}
