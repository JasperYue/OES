package com.augmentum.service;

import com.augmentum.model.User;

public interface UserService {

    /**
     * Business logical method of user login.
     * @param user
     * @return if user exist, return user. if not, throw exception.
     */
    public User login(User user);

}
