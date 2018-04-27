package com.augmentum.dao.impl;

import java.util.ArrayList;
import java.util.List;

import com.augmentum.dao.ExamDao;
import com.augmentum.model.Exam;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.StringUtil;

public class ExamDaoImpl extends BaseDao<Exam> implements ExamDao{

    @Override
    public long addExam(Exam exam) {
        String sql = "INSERT INTO exam(name, description, single_score , "
                + "total_score , pass_criteria , need_quantity , fact_quantity, "
                + "effective_time , duration, creator, answer_str , status, create_time , "
                + "update_time) VALUES(?, ?, ?, ?, ?, ?, ?, str_to_date(?, '%Y-%m-%d %H:%i'), ?, ?, ?, ?, now(), now() )";
        if (StringUtil.isEmpty(exam.getDescription())) {
            return insert(sql, exam.getName(), "", exam.getSingleScore(), exam.getTotalScore(),
                    exam.getPassCriteria(), exam.getNeedQuantity(), exam.getFactQuantity(),
                    exam.getEffectiveTime(), exam.getDuration(), exam.getCreator(), exam.getAnswerStr(),
                    exam.getStatus());
        }
        return insert(sql, exam.getName(), exam.getDescription(), exam.getSingleScore(), exam.getTotalScore(),
                exam.getPassCriteria(), exam.getNeedQuantity(), exam.getFactQuantity(),
                exam.getEffectiveTime(), exam.getDuration(), exam.getCreator(), exam.getAnswerStr(),
                exam.getStatus());
    }

    @Override
    public List<Exam> findExamList(FuzzyCriterion<Exam> fuzzyCriterion) {
        List<Object> objList = new ArrayList<>();

        StringBuffer sql = new StringBuffer("SELECT id, num, name, "
                + "need_quantity 'needQuantity', fact_quantity 'factQuantity', "
                + "effective_time 'effectiveTime', duration, creator, status "
                + "FROM exam WHERE name LIKE ? AND effective_time BETWEEN str_to_date(?, '%Y-%m-%d') "
                + "AND str_to_date(?, '%Y-%m-%d')");
        objList.add(fuzzyCriterion.getTitle());
        objList.add(fuzzyCriterion.getTimeBegin());
        objList.add(fuzzyCriterion.getTimeEnd());

        if (!StringUtil.isEmpty(fuzzyCriterion.getOrderField())) {
            sql.append("ORDER BY ? ");
            objList.add(fuzzyCriterion.getOrderField());
        }
        sql.append("LIMIT ?, ?");
        objList.add((fuzzyCriterion.getPage().getPageNo() - 1) * fuzzyCriterion.getPage().getPageSize());
        objList.add(fuzzyCriterion.getPage().getPageSize());
        return getObjList(sql.toString(), objList.toArray());
    }

    @Override
    public int getExamCount(FuzzyCriterion<Exam> fuzzyCriterion) {
        StringBuffer sql = new StringBuffer("SELECT COUNT(*) FROM exam WHERE name LIKE ? ");
        Long count = 0L;
        if (!StringUtil.isEmpty(fuzzyCriterion.getTimeEnd())) {
            sql.append("AND effective_time BETWEEN str_to_date(?, '%Y-%d-%m') AND str_to_date(?, '%Y-%d-%m') ");
            count = getSingleVal(sql.toString(), fuzzyCriterion.getTitle(), fuzzyCriterion.getTimeBegin(), fuzzyCriterion.getTimeEnd());
        } else {
            count = getSingleVal(sql.toString(), fuzzyCriterion.getTitle());
        }
        return count.intValue();
    }

    @Override
    public boolean editExam(Exam exam) {
        String sql = "UPDATE exam SET num = ? WHERE id = ?";
        return update(sql, exam.getNum(), exam.getId()) > 0;
    }

    @Override
    public int batchInsertQuestionToPaper(Exam exam, Object[]... params) {
        String sql = "INSERT exam_question(exam_id, question_id) VALUES(" + exam.getId() + ", ?)";
        return batch(sql, params);
    }

}
