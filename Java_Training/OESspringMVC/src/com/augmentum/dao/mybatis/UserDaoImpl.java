package com.augmentum.dao.mybatis;

import org.mybatis.spring.support.SqlSessionDaoSupport;

import com.augmentum.dao.UserDao;
import com.augmentum.model.User;

public class UserDaoImpl
    extends SqlSessionDaoSupport implements UserDao {

    private static final String CLASS_NAME = User.class.getName();
    private static final String SQL_ID_USER_LOGIN = ".login";

    @Override
    public User login(User user) {
        return getSqlSession().selectOne(CLASS_NAME + SQL_ID_USER_LOGIN, user);
    }

}
