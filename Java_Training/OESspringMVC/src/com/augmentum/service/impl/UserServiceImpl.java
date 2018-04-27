package com.augmentum.service.impl;

import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

import com.augmentum.dao.UserDao;
import com.augmentum.exception.ParamException;
import com.augmentum.exception.ServiceException;
import com.augmentum.model.User;
import com.augmentum.service.UserService;
import com.augmentum.util.MessageUtil;
import com.augmentum.util.StringUtil;

public class UserServiceImpl implements UserService {

    private UserDao userDao;

    public void setUserDao(UserDao userDao) {
        this.userDao = userDao;
    }

    @Override
    public User login(User user) {
        Map<String, String> errMsgMap = new ConcurrentHashMap<>();
        /*
         * Validate the data according the rules below:
         * 1.userName can not be empty
         * 2.password can not be empty
         */
        if (StringUtil.isEmpty(user.getName())) {
            errMsgMap.put(User.NAME,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR,
                            User.NAME, User.USER));
        }

        if (StringUtil.isEmpty(user.getPassword())) {
            errMsgMap.put(User.PASSWORD,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR,
                            User.PASSWORD, User.USER));
        }

        if (!errMsgMap.isEmpty()) {
            throw new ParamException(MessageUtil.DATA_VALIDATE_ERROR,
                    MessageUtil.buildMessage(MessageUtil.DATA_VALIDATE_ERROR),
                    errMsgMap);
        }

        user = userDao.login(user);

        /*
         * User business logical judgment
         * if Object is null, that means this user not exist in our system
         * or the users' password is not correct, and we just give a tip
         * blurry
         */
        if (user == null) {
            throw new ServiceException(MessageUtil.ENTITY_NOT_FOUND,
                    MessageUtil.buildMessage(MessageUtil.ENTITY_NOT_FOUND,
                            User.USER));
        }

        return user;
    }

}
