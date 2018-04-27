package com.augmentum.dao.mybatis;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.mybatis.spring.support.SqlSessionDaoSupport;

import com.augmentum.dao.QuestionDao;
import com.augmentum.model.Exam;
import com.augmentum.model.Question;
import com.augmentum.util.FuzzyCriterion;

public class QuestionDaoImpl
    extends SqlSessionDaoSupport implements QuestionDao {

    private static final String CLASS_NAME = Question.class.getName();
    private static final String SQL_ID_ADD_QUESTION = ".addQuestion";
    private static final String SQL_ID_EDIT_QUESTION = ".editQuestion";
    private static final String SQL_ID_DELETE_QUESTION = ".deleteQuestion";
    private static final String SQL_ID_GET_QUESTION = ".getQuestion";
    private static final String SQL_ID_FIND_QUESTION = ".findQuestion";
    private static final String SQL_ID_GET_QUESTION_COUNT = ".getQuestionCount";
    private static final String SQL_ID_FIND_QUESTION_ID_LIST = ".findQuestionIdList";
    private static final String SQL_ID_BATCH_EDIT_QUESTION = ".batchEditQuestion";

    @Override
    public long addQuestion(Question question) {
        getSqlSession().insert(CLASS_NAME + SQL_ID_ADD_QUESTION, question);
        return question.getId();
    }

    @Override
    public boolean editQuestion(Question question) {
        return getSqlSession().update(CLASS_NAME + SQL_ID_EDIT_QUESTION, question) > 0;
    }

    @Override
    public int deleteQuestion(Object[]... objArr) {
        List<Object> objList = new ArrayList<>();
        for (int i = 0; i < objArr.length; i++) {
            objList.add(objArr[i][0]);
        }
        return getSqlSession().update(CLASS_NAME + SQL_ID_DELETE_QUESTION, objList);
    }

    @Override
    public Question getQuestion(Question question) {
        return getSqlSession().selectOne(CLASS_NAME + SQL_ID_GET_QUESTION, question);
    }

    @Override
    public List<Question> findQuestion(FuzzyCriterion<Question> fuzzyCriterion) {
        Map<String, Object> args = new HashMap<>();
        args.put(FuzzyCriterion.TITLE, fuzzyCriterion.getTitle());
        args.put(FuzzyCriterion.ORDER_FIELD, fuzzyCriterion.getOrderField());
        args.put("startItem", (fuzzyCriterion.getPage().getPageNo() - 1) * fuzzyCriterion.getPage().getPageSize());
        args.put("endItem", fuzzyCriterion.getPage().getPageSize());
        return getSqlSession().selectList(CLASS_NAME + SQL_ID_FIND_QUESTION, args);
    }

    @Override
    public int getQuestionCount(FuzzyCriterion<Question> fuzzyCriterion) {
        String title = null;
        if (fuzzyCriterion == null) {
            title = "%%";
        } else {
            title = fuzzyCriterion.getTitle();
        }
        return getSqlSession().selectOne(CLASS_NAME + SQL_ID_GET_QUESTION_COUNT, title);
    }

    @Override
    public List<Question> findQuestionIdList(Exam exam) {
        return getSqlSession().selectList(CLASS_NAME + SQL_ID_FIND_QUESTION_ID_LIST, exam.getNeedQuantity());
    }

    @Override
    public int batchEditQuestion(Object[]... objArr) {
        List<Object> objList = new ArrayList<>();
        for (int i = 0; i < objArr.length; i++) {
            objList.add(objArr[i][0]);
        }
        return getSqlSession().update(CLASS_NAME + SQL_ID_BATCH_EDIT_QUESTION, objList);
    }

}
