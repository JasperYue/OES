package com.augmentum.dao.impl;

import java.util.List;

import com.augmentum.Constants;
import com.augmentum.dao.QuestionDao;
import com.augmentum.model.Exam;
import com.augmentum.model.Question;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.StringUtil;

public class QuestionDaoImpl extends BaseDao<Question> implements QuestionDao {

    @Override
    public long addQuestion(Question question) {
        if (question.getCreateTime() != null) {
            String sql = "INSERT INTO question(num, title, item_A, item_B, item_C, item_D, answer, create_time, update_time) VALUES(?, ?, ?, ?, ?, ?, ?, ?, now())";
            return insert(sql, question.getNum(), question.getTitle(), question.getItemA(),
                    question.getItemB(), question.getItemC(), question.getItemD(),
                    question.getAnswer(), question.getCreateTime());
        } else {
            String sql = "INSERT INTO question(num, title, item_A, item_B, item_C, item_D, answer, create_time, update_time) VALUES(?, ?, ?, ?, ?, ?, ?, now(), now())";
            return insert(sql, question.getNum(), question.getTitle(), question.getItemA(),
                    question.getItemB(), question.getItemC(), question.getItemD(),
                    question.getAnswer());
        }
    }

    @Override
    public List<Question> getPaper(Exam exam) {
        return getObjList("");
    }

    @Override
    public boolean editQuestion(Question question) {
        String sql = "UPDATE question SET num = ?, title = ?,"
                + " item_A = ?, item_B = ?, item_C = ?,"
                + " item_D = ?, answer = ?, update_time = now() WHERE id = ?";
        return update(sql, question.getNum(), question.getTitle(), question.getItemA(),
                question.getItemB(), question.getItemC(), question.getItemD(),
                question.getAnswer(),question.getId()) > 0;
    }

    @Override
    public int deleteQuestion(Object[]... objArr) {
        String sql = "UPDATE question SET del_mark = 1 WHERE id = ?";
        return batch(sql, objArr);
    }

    @Override
    public Question getQuestion(Question question) {
        String sql = "SELECT  id, num, title, item_A 'itemA', item_B 'itemB', item_C 'itemC', item_D 'itemD', answer, del_mark 'delMark', refer_mark 'referMark', create_time 'createTime', update_time 'updateTime' FROM question "
                + "WHERE del_mark = 0 AND id = ?";
        return getObject(sql, question.getId());
    }

    @Override
    public List<Question> findQuestion(FuzzyCriterion<Question> fuzzyCriterion) {
        StringBuffer sql = new StringBuffer("SELECT id, num, title, item_A 'itemA', item_B 'itemB', item_C 'itemC', item_D 'itemD', answer, del_mark 'delMark', refer_mark 'referMark', create_time 'createTime', update_time 'updateTime' FROM question "
                + "WHERE del_mark = 0 AND title LIKE ? ");
        String orderField = fuzzyCriterion.getOrderField();

        if (!StringUtil.isEmpty(orderField) &&
                StringUtil.isEquals(String.valueOf(Constants.STATUS_ZERO), orderField)) {
            orderField = " ASC ";
        } else {
            orderField = " DESC ";
        }

        sql.append("ORDER BY num"+ orderField +"LIMIT ?, ?");
        return getObjList(new String(sql), fuzzyCriterion.getTitle(),
                (fuzzyCriterion.getPage().getPageNo() - 1) * fuzzyCriterion.getPage().getPageSize(),
                fuzzyCriterion.getPage().getPageSize());
    }

    @Override
    public int getQuestionCount(FuzzyCriterion<Question> fuzzyCriterion) {
        String sql = "SELECT COUNT(*) FROM question WHERE del_mark = 0 AND title LIKE ?";
        Long count = 0L;
        if (fuzzyCriterion == null) {
            count = getSingleVal(sql, "%%");
        } else {
            count = getSingleVal(sql, fuzzyCriterion.getTitle());
        }
        return count.intValue();
    }

    @Override
    public List<Question> findQuestionIdList(Exam exam) {
        String sql = "SELECT id, answer, refer_mark 'referMark' FROM question ORDER BY RAND() LIMIT ?";
        return getObjList(sql, exam.getNeedQuantity());
    }

    @Override
    public int batchEditQuestion(Object[]... objArr) {
        String sql = "UPDATE question SET refer_mark = 1 WHERE id = ? ";
        return batch(sql, objArr);
    }

}
