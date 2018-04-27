package com.augmentum.dao.impl;

import java.util.List;

import com.augmentum.dao.RoleDao;
import com.augmentum.model.Role;

public class RoleDaoImpl extends BaseDao<Role> implements RoleDao{

    @Override
    public List<Role> findRoleList() {
        return getObjList("");
    }

}
