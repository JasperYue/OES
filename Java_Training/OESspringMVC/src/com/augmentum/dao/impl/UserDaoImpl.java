package com.augmentum.dao.impl;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;

import com.augmentum.dao.UserDao;
import com.augmentum.model.User;
import com.augmentum.util.JDBCUtil;

/**
 * The implementation of specific database's method on user
 * @author Jasper.yue
 *
 */
public class UserDaoImpl implements UserDao {

    private JdbcTemplate jdbcTemplate;

    public void setJdbcTemplate(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public User login(User user) {
        String sql = "SELECT id, name, password, gender, tel, email, role_id 'roleId', del_mark 'delMark' FROM user WHERE name = ? AND password = ?";
        Object[] args = {user.getName(), user.getPassword()};
        List<User> userList = jdbcTemplate.query(sql, args, new RowMapper<User>() {
            @Override
            public User mapRow(ResultSet rs, int rowNum) throws SQLException {
                return JDBCUtil.data2Obj(User.class, rs);
            }
        });

        if (userList !=null && userList.size() > 0) {
            return userList.get(0);
        }

        return null;

    }
}
