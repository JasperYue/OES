package com.augmentum.dao.mybatis;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.mybatis.spring.support.SqlSessionDaoSupport;

import com.augmentum.dao.ExamDao;
import com.augmentum.model.Exam;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.StringUtil;

public class ExamDaoImpl
    extends SqlSessionDaoSupport implements ExamDao {

    private static final String CLASS_NAME = Exam.class.getName();
    private static final String SQL_ID_ADD_EXAM = ".addExam";
    private static final String SQL_ID_FIND_EXAM_LIST = ".findExamList";
    private static final String SQL_ID_GET_EXAM_COUNT = ".getExamCount";
    private static final String SQL_ID_BATCH_INSERT_QUESTION_TO_PAPER = ".batchInsertQuestionToPaper";
    private static final String SQL_ID_EDIT_EXAM = ".editExam";

    @Override
    public long addExam(Exam exam) {
        getSqlSession().insert(CLASS_NAME + SQL_ID_ADD_EXAM, exam);
        return exam.getId();
    }

    @Override
    public List<Exam> findExamList(FuzzyCriterion<Exam> fuzzyCriterion) {
        Map<String, Object> args = new HashMap<>();
        args.put(FuzzyCriterion.TITLE, fuzzyCriterion.getTitle());
        args.put(FuzzyCriterion.TIME_BEGIN, fuzzyCriterion.getTimeBegin());
        args.put(FuzzyCriterion.TIME_END, fuzzyCriterion.getTimeEnd());
        if (!StringUtil.isEmpty(fuzzyCriterion.getOrderField())) {
            args.put(FuzzyCriterion.ORDER_FIELD, fuzzyCriterion.getOrderField());
        }
        args.put("itemStart", (fuzzyCriterion.getPage().getPageNo() - 1) * fuzzyCriterion.getPage().getPageSize());
        args.put("itemEnd", fuzzyCriterion.getPage().getPageSize());
        return getSqlSession().selectList(CLASS_NAME + SQL_ID_FIND_EXAM_LIST, args);
    }

    @Override
    public int getExamCount(FuzzyCriterion<Exam> fuzzyCriterion) {
        Map<String, Object> args = new HashMap<>();
        args.put(Exam.NAME, fuzzyCriterion.getTitle());
        if (!StringUtil.isEmpty(fuzzyCriterion.getTimeEnd())) {
            args.put(FuzzyCriterion.TIME_BEGIN, fuzzyCriterion.getTimeBegin());
            args.put(FuzzyCriterion.TIME_END, fuzzyCriterion.getTimeEnd());
        }
        return getSqlSession().selectOne(CLASS_NAME + SQL_ID_GET_EXAM_COUNT, args);
    }

    @Override
    public int batchInsertQuestionToPaper(Exam exam, Object[]... params) {
        Map<String, Object> args = new HashMap<>();
        args.put(Exam.ID, exam.getId());
        List<Object> objList = new ArrayList<>();
        for (int i = 0; i < params.length; i++) {
            objList.add(params[i][0]);
        }
        args.put("idList", objList);
        return getSqlSession().update(CLASS_NAME + SQL_ID_BATCH_INSERT_QUESTION_TO_PAPER, args);
    }

    @Override
    public boolean editExam(Exam exam) {
        return getSqlSession().update(CLASS_NAME + SQL_ID_EDIT_EXAM, exam) > 0;
    }

}
