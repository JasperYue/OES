package com.augmentum.dao;

import com.augmentum.model.User;

public interface UserDao {

    /**
     * User login system.
     * @param user
     * @return user
     */
    public User login(User user);

}
