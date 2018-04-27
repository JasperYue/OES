package com.augmentum.dao.impl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.support.GeneratedKeyHolder;
import org.springframework.jdbc.support.KeyHolder;

import com.augmentum.dao.ExamDao;
import com.augmentum.model.Exam;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.JDBCUtil;
import com.augmentum.util.StringUtil;

public class ExamDaoImpl implements ExamDao {

    private JdbcTemplate jdbcTemplate;

    public void setJdbcTemplate(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    //TODO
    @Override
    public long addExam(final Exam exam) {
        final String sql = "INSERT INTO exam(name, description, single_score , "
                + "total_score , pass_criteria , need_quantity , fact_quantity, "
                + "effective_time , duration, creator, answer_str , status, create_time , "
                + "update_time) VALUES(?, ?, ?, ?, ?, ?, ?, str_to_date(?, '%Y-%m-%d %H:%i'), ?, ?, ?, ?, now(), now() )";
        if (StringUtil.isEmpty(exam.getDescription())) {

            KeyHolder keyHolder = new GeneratedKeyHolder();
            jdbcTemplate.update(new PreparedStatementCreator() {
                @Override
                public PreparedStatement createPreparedStatement(Connection connection) throws SQLException {

                    PreparedStatement ps = connection.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
                    Object[] args = {exam.getName(), "", exam.getSingleScore(), exam.getTotalScore(),
                            exam.getPassCriteria(), exam.getNeedQuantity(), exam.getFactQuantity(),
                            exam.getEffectiveTime(), exam.getDuration(), exam.getCreator(), exam.getAnswerStr(),
                            exam.getStatus()};
                    JDBCUtil.fillParams(ps, args);

                    return ps;
                }
            }, keyHolder);

            return keyHolder.getKey().intValue();

        }
        KeyHolder keyHolder = new GeneratedKeyHolder();
        jdbcTemplate.update(new PreparedStatementCreator() {
            @Override
            public PreparedStatement createPreparedStatement(Connection connection) throws SQLException {

                PreparedStatement ps = connection.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
                Object[] args = {exam.getName(), exam.getDescription(), exam.getSingleScore(), exam.getTotalScore(),
                        exam.getPassCriteria(), exam.getNeedQuantity(), exam.getFactQuantity(),
                        exam.getEffectiveTime(), exam.getDuration(), exam.getCreator(), exam.getAnswerStr(),
                        exam.getStatus()};
                JDBCUtil.fillParams(ps, args);

                return ps;
            }
        }, keyHolder);

        return keyHolder.getKey().intValue();
    }

    @Override
    public List<Exam> findExamList(final FuzzyCriterion<Exam> fuzzyCriterion) {
        final List<Object> objList = new ArrayList<>();

        final StringBuffer sql = new StringBuffer("SELECT id, num, name, "
                + "need_quantity 'needQuantity', fact_quantity 'factQuantity', "
                + "effective_time 'effectiveTime', duration, creator, status "
                + "FROM exam WHERE name LIKE ? AND effective_time BETWEEN str_to_date(?, '%Y-%m-%d') "
                + "AND str_to_date(?, '%Y-%m-%d')");
        objList.add(fuzzyCriterion.getTitle());
        objList.add(fuzzyCriterion.getTimeBegin());
        objList.add(fuzzyCriterion.getTimeEnd());

        if (!StringUtil.isEmpty(fuzzyCriterion.getOrderField())) {
            sql.append(" ORDER BY " + fuzzyCriterion.getOrderField());
        }
        sql.append(" LIMIT ?, ?");
        objList.add((fuzzyCriterion.getPage().getPageNo() - 1) * fuzzyCriterion.getPage().getPageSize());
        objList.add(fuzzyCriterion.getPage().getPageSize());
        return jdbcTemplate.query(new PreparedStatementCreator() {

            @Override
            public PreparedStatement createPreparedStatement(Connection conn) throws SQLException {

                PreparedStatement ps = conn.prepareStatement(sql.toString());

                Object[] args = objList.toArray();
                JDBCUtil.fillParams(ps, args);

                return ps;
            }

        }, new RowMapper<Exam>() {

            @Override
            public Exam mapRow(ResultSet rs, int rowNum) throws SQLException {
                return JDBCUtil.data2Obj(Exam.class, rs);
            }
        });

    }

    @Override
    public int getExamCount(FuzzyCriterion<Exam> fuzzyCriterion) {
        StringBuffer sql = new StringBuffer("SELECT COUNT(*) FROM exam WHERE name LIKE ? ");
        int count = 0;
        if (!StringUtil.isEmpty(fuzzyCriterion.getTimeEnd())) {
            sql.append("AND effective_time BETWEEN str_to_date(?, '%Y-%d-%m') AND str_to_date(?, '%Y-%d-%m') ");
            count = jdbcTemplate.queryForInt(sql.toString(), new Object[]{fuzzyCriterion.getTitle(), fuzzyCriterion.getTimeBegin(), fuzzyCriterion.getTimeEnd()});
        } else {
            count = jdbcTemplate.queryForInt(sql.toString(), new Object[]{fuzzyCriterion.getTitle()});
        }
        return count;
    }
    //TODO
    @Override
    public boolean editExam(Exam exam) {
        String sql = "UPDATE exam SET num = ? WHERE id = ?";
        return jdbcTemplate.update(sql, exam.getNum(), exam.getId()) > 0;
    }

    @Override
    public int batchInsertQuestionToPaper(Exam exam, final Object[]... params) {
        String sql = "INSERT exam_question(exam_id, question_id) VALUES(" + exam.getId() + ", ?)";

        int size = 0;
        for (int i = 0; i < params.length; i++) {
            size += jdbcTemplate.update(sql, params[i][0]);
        }

        return size;

    }

}
