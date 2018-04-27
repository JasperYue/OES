package com.augmentum.dao;

import java.util.List;

import com.augmentum.model.Role;

public interface RoleDao {

    /**
     * Find role list.
     * @return
     */
    public List<Role> findRoleList();

}
