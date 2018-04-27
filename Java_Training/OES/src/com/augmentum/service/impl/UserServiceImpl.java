package com.augmentum.service.impl;

import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

import com.augmentum.dao.UserDao;
import com.augmentum.dao.impl.UserDaoImpl;
import com.augmentum.exception.ParamException;
import com.augmentum.exception.ServiceException;
import com.augmentum.model.User;
import com.augmentum.service.UserService;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.MessageUtil;
import com.augmentum.util.Page;
import com.augmentum.util.StringUtil;

public class UserServiceImpl implements UserService{

    private UserDao userDao;

    public void setUserDao(UserDaoImpl userDaoImpl) {
        this.userDao = userDaoImpl;
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
            errMsgMap.put(MessageUtil.ENTITY_USER_NAME,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR,
                            MessageUtil.ENTITY_USER_NAME, MessageUtil.ENTITY_USER));
        }

        if (StringUtil.isEmpty(user.getPassword())) {
            errMsgMap.put(MessageUtil.ENTITY_USER_PASSWORD,
                    MessageUtil.buildMessage(MessageUtil.REQUIRED_FIELD_ERROR,
                            MessageUtil.ENTITY_USER_PASSWORD, MessageUtil.ENTITY_USER));
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
                            MessageUtil.ENTITY_USER));
        }

        return user;
    }

    @Override
    public void addUser(User user) {

        // Pass 1: validate the data from Front-end


        // Pass 2: insert user into database if the data is correct
        boolean flag = userDao.addUser(user);
        if (!flag) {
            throw new ServiceException("Fail to add user");
        }
    }

    @Override
    public void deleteUser(User user) {
        // 单个或批量删除  根据业务 1.出现失败 全失败 2.其他成功 失败的失败
    }

    @Override
    public void editUser(User user) {
    }

    @Override
    public Page<User> getUserList(FuzzyCriterion<User> fuzzyCriterion) {

//        /** Get number of record in database */
//        int record = userDao.getUserCount(fuzzyCriterion);
//
//        Page<User> page = new Page<User>(fuzzyCriterion.getPageNo());
//
//        if (record != 0) {
//            page.setTotalItem(userDao.getUserCount(fuzzyCriterion));
//        } else {
//            throw new ServiceException("Fail to get number of record");
//        }
//
//        /** get user list by pagination */
//        List<User> userList = userDao.findUserList(fuzzyCriterion, page.getPageSize());
//
//        if (userList != null) {
//            page.setPageList(userList);
//        } else {
//            throw new ServiceException("Fail to get user list");
//        }
//
        return null;
    }

    @Override
    public User getUser(User user) {
        // TODO Auto-generated method stub
        return null;
    }

}
