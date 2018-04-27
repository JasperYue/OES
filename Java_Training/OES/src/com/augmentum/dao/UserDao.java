package com.augmentum.dao;

import java.util.List;

import com.augmentum.model.User;
import com.augmentum.util.FuzzyCriterion;

public interface UserDao {

    /**
     * User log into system
     * @param user
     * @return
     */
    public User login(User user);

    /**
     * Get user details.
     * @param user
     * @return
     */
    public User getUser(User user);

    /**
     * Add a user into system
     * @param user
     * @return
     */
    public boolean addUser(User user);

    /**
     * Delete a user in logical way
     * @param user
     * @return
     */
    public boolean deleteUser(User user);

    /**
     * Edit user's profile, incluing modify password
     * @param user
     * @return
     */
    public boolean editUser(User user);

    /**
     * Get count of user on specific condition
     * @param fuzzyCriterion
     * @return
     */
    public int getUserCount(FuzzyCriterion<User> fuzzyCriterion);

    /**
     * Find userList on specific condition
     * @param fuzzyCriterion
     * @return
     */
    public List<User> findUserList(FuzzyCriterion<User> fuzzyCriterion, int pageSize);

}
