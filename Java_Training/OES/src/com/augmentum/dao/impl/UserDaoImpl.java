package com.augmentum.dao.impl;

import java.util.List;

import com.augmentum.dao.UserDao;
import com.augmentum.model.User;
import com.augmentum.util.FuzzyCriterion;

/**
 * The implementation of specific database's method on user
 * @author Jasper.yue
 *
 */
public class UserDaoImpl extends BaseDao<User> implements UserDao {

    @Override
    public User login(User user) {
        String sql = "SELECT id, name, password, gender, tel, email, role_id 'roleId', del_mark 'delMark' FROM user WHERE name = ? AND password = ?";
        return getObject(sql, user.getName(), user.getPassword());
    }

    @Override
    public boolean addUser(User user) {
        String sql = "INSERT INTO user('name', 'password', 'gender', 'tel', 'email', 'role_id')";
        int size = update(sql, user.getName(), user.getPassword(), user.getGender(), user.getTel(), user.getEmail(),user.getRoleId());
        return size > 0;
    }

    @Override
    public boolean deleteUser(User user) {
        String sql = "UPDATE user SET delMark = 1 WHERE id = ?";
        int size = update(sql, user.getId());
        return size > 0;
    }

    @Override
    public boolean editUser(User user) {
        String sql = "UPDATE user set name = ?, password = ?, gender = ?, tel = ?, email = ?, role_id = ? WHERE id = ?";
        int size = update(sql, user.getName(), user.getPassword(), user.getGender(), user.getTel(), user.getEmail(), user.getRoleId(), user.getId());
        return size > 0;
    }
    /*
    @Override
    public int getUserCount(FuzzyCriterion<User> fuzzyCriterion) {
        StringBuffer sb = new StringBuffer("SELECT COUNT(*) FROM user ");
        Long count = getSingleVal(new String(sqlPackage(sb, fuzzyCriterion)), fuzzyCriterion.getTitle(), fuzzyCriterion.getParams(), fuzzyCriterion.getCondition());
        return count == null ? 0 : count.intValue();
    }

    @Override
    public List<User> findUserList(FuzzyCriterion<User> fuzzyCriterion, int pageSize) {
        StringBuffer sb = new StringBuffer("SELECT id, name, password, gender, tel, email, role_id 'roleId', delMark) FROM user ");
        StringBuffer sql = sqlPackage(sb, fuzzyCriterion);
        sql.append("limit ?, ? ");
        return null;
//        return getObjList(new String(sql), fuzzyCriterion.getTitle(),
//                fuzzyCriterion.getParams(), fuzzyCriterion.getCondition(),
//                fuzzyCriterion.getPageNo() - 1 * pageSize, pageSize);
    }

    private StringBuffer sqlPackage(StringBuffer sb, FuzzyCriterion<User> fuzzyCriterion) {
        int[] params = fuzzyCriterion.getParams();
        String title = fuzzyCriterion.getTitle();
        String condition = fuzzyCriterion.getCondition();

        // Pass 1: fuzzy search by role_id or title
        boolean flag = false;

        if (title != null) {
            sb.append("WHERE name LIKE ? ");
            flag = true;
        }

        if (params != null) {
            if (flag) {
                sb.append("and role_id = ? ");
            } else {
                sb.append("WHERE role_id = ? ");
            }

            int length = params.length;
            if (length > 1) {
                for (int i = 1; i < params.length; i++) {
                    sb.append("or role_id = ? ");
                }
            }
        }

        if (condition != null) {
            sb.append("ORDER BY ? ");
        }

        return sb;
    }

    @Override
    public User getUser(User user) {
        return null;
    }
*/

    @Override
    public User getUser(User user) {
        // TODO Auto-generated method stub
        return null;
    }

    @Override
    public int getUserCount(FuzzyCriterion<User> fuzzyCriterion) {
        // TODO Auto-generated method stub
        return 0;
    }

    @Override
    public List<User> findUserList(FuzzyCriterion<User> fuzzyCriterion, int pageSize) {
        // TODO Auto-generated method stub
        return null;
    }
}
