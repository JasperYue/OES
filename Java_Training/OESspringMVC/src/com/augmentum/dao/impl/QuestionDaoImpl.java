package com.augmentum.dao.impl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.support.GeneratedKeyHolder;
import org.springframework.jdbc.support.KeyHolder;

import com.augmentum.Constants;
import com.augmentum.dao.QuestionDao;
import com.augmentum.model.Exam;
import com.augmentum.model.Question;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.JDBCUtil;
import com.augmentum.util.StringUtil;

public class QuestionDaoImpl implements QuestionDao {

    private JdbcTemplate jdbcTemplate;


    public void setJdbcTemplate(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public long addQuestion(final Question question) {
        if (question.getCreateTime() != null) {

            KeyHolder keyHolder = new GeneratedKeyHolder();
            jdbcTemplate.update(new PreparedStatementCreator() {
                @Override
                public PreparedStatement createPreparedStatement(Connection connection) throws SQLException {

                    String sql = "INSERT INTO question(num, title, item_A, item_B, item_C, item_D, answer, create_time, update_time) VALUES(?, ?, ?, ?, ?, ?, ?, ?, now())";

                    PreparedStatement ps = connection.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
                    Object[] args = {question.getNum(), question.getTitle(), question.getItemA(),
                               question.getItemB(), question.getItemC(), question.getItemD(),
                               question.getAnswer(), question.getCreateTime()};
                    JDBCUtil.fillParams(ps, args);

                    return ps;
                }
            }, keyHolder);

            return keyHolder.getKey().intValue();

        } else {

            KeyHolder keyHolder = new GeneratedKeyHolder();
            jdbcTemplate.update(new PreparedStatementCreator() {
                @Override
                public PreparedStatement createPreparedStatement(Connection connection) throws SQLException {

                    String sql = "INSERT INTO question(num, title, item_A, item_B, item_C, item_D, answer, create_time, update_time) VALUES(?, ?, ?, ?, ?, ?, ?, now(), now())";
                    PreparedStatement ps = connection.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
                    Object[] args = {question.getNum(), question.getTitle(), question.getItemA(),
                               question.getItemB(), question.getItemC(), question.getItemD(),
                               question.getAnswer()};
                    JDBCUtil.fillParams(ps, args);
                    return ps;
                }
            }, keyHolder);

            return keyHolder.getKey().intValue();
        }
    }

    @Override
    public boolean editQuestion(Question question) {
        String sql = "UPDATE question SET num = ?, title = ?,"
                + " item_A = ?, item_B = ?, item_C = ?,"
                + " item_D = ?, answer = ?, update_time = now() WHERE id = ?";
        return jdbcTemplate.update(sql, question.getNum(), question.getTitle(), question.getItemA(),
                question.getItemB(), question.getItemC(), question.getItemD(),
                question.getAnswer(), question.getId()) > 0;
    }

    @Override
    public Question getQuestion(Question question) {
        String sql = "SELECT  id, num, title, item_A 'itemA', item_B 'itemB', item_C 'itemC', item_D 'itemD', answer, del_mark 'delMark', refer_mark 'referMark', create_time 'createTime', update_time 'updateTime' FROM question "
                + "WHERE del_mark = 0 AND id = ?";

        Object[] args = {question.getId()};
        List<Question> questionList = jdbcTemplate.query(sql, args, new RowMapper<Question>() {

            @Override
            public Question mapRow(ResultSet rs, int rowNum) throws SQLException {
                return JDBCUtil.data2Obj(Question.class, rs);
            }
        });

        if (questionList !=null && questionList.size() > 0) {
            return questionList.get(0);
        }

        return null;
    }

    @Override
    public List<Question> findQuestion(final FuzzyCriterion<Question> fuzzyCriterion) {

        final StringBuffer sql = new StringBuffer("SELECT id, num, title, item_A 'itemA', item_B 'itemB', item_C 'itemC', item_D 'itemD', answer, del_mark 'delMark', refer_mark 'referMark', create_time 'createTime', update_time 'updateTime' FROM question "
                + "WHERE del_mark = 0 AND title LIKE ? ");
        String orderField = fuzzyCriterion.getOrderField();

        if (!StringUtil.isEmpty(orderField) &&
                StringUtil.isEquals(String.valueOf(Constants.STATUS_ZERO), orderField)) {
            orderField = " ASC ";
        } else {
            orderField = " DESC ";
        }

        sql.append("ORDER BY num"+ orderField +"LIMIT ?, ?");

        return jdbcTemplate.query(new PreparedStatementCreator() {

            @Override
            public PreparedStatement createPreparedStatement(Connection conn) throws SQLException {

                PreparedStatement ps = conn.prepareStatement(sql.toString());

                Object[] args = {fuzzyCriterion.getTitle(),
                        (fuzzyCriterion.getPage().getPageNo() - 1) * fuzzyCriterion.getPage().getPageSize(),
                        fuzzyCriterion.getPage().getPageSize()};
                JDBCUtil.fillParams(ps, args);

                return ps;
            }

        }, new RowMapper<Question>() {

            @Override
            public Question mapRow(ResultSet rs, int rowNum) throws SQLException {
                return JDBCUtil.data2Obj(Question.class, rs);
            }
        });

    }

    @Override
    public int getQuestionCount(FuzzyCriterion<Question> fuzzyCriterion) {
        String sql = "SELECT COUNT(*) FROM question WHERE del_mark = 0 AND title LIKE ?";
        int count = 0;
        if (fuzzyCriterion == null) {
            count = jdbcTemplate.queryForInt(sql, "%%");
        } else {
            count = jdbcTemplate.queryForInt(sql, fuzzyCriterion.getTitle());
        }

        return count;
    }

    @Override
    public List<Question> findQuestionIdList(Exam exam) {
        String sql = "SELECT id, answer, refer_mark 'referMark' FROM question ORDER BY RAND() LIMIT ?";

        Object[] args = {exam.getNeedQuantity()};
        return jdbcTemplate.query(sql, args, new RowMapper<Question>() {

            @Override
            public Question mapRow(ResultSet rs, int rowNum) throws SQLException {
                return JDBCUtil.data2Obj(Question.class, rs);
            }
        });

    }

    @Override
    public int batchEditQuestion(final Object[]... objArr) {
        String sql = "UPDATE question SET refer_mark = 1 WHERE id = ? ";

        int size = 0;
        for (int i = 0; i < objArr.length; i++) {
            size += jdbcTemplate.update(sql, objArr[i][0]);
        }

        return size;
    }

    @Override
    public int deleteQuestion(final Object[]... objArr) {
        String sql = "UPDATE question SET del_mark = 1 WHERE id = ?";

        int size = 0;
        for (int i = 0; i < objArr.length; i++) {
            size += jdbcTemplate.update(sql, objArr[i][0]);
        }

        return size;
    }

}
