package com.augmentum.service;

import com.augmentum.model.User;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.Page;

public interface UserService {

    /**
     * Business logical method of user login.
     * @param user
     * @return if user exist, return user. if not, throw exception.
     */
    public User login(User user);

    /**
     * Get user details.
     * @param user
     * @return if user exist, return user. if not, throw exception.
     */
    public User getUser(User user);

    /**
     * Add a user into system.
     * @param user
     */
    public void addUser(User user);

    /**
     * Delete a user in logical way.
     * @param user
     */
    public void deleteUser(User user);

    /**
     * Edit user's profile, incluing modify password.
     * @param user
     */
    public void editUser(User user);

    /**
     * Fuzzy search user by pagination and conditions.
     * @param fuzzyCriterion
     * @return user list fit for all conditions
     */
    public Page<User> getUserList(FuzzyCriterion<User> fuzzyCriterion);

}
