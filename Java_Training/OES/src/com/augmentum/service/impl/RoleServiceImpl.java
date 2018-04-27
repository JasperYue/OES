package com.augmentum.service.impl;

import java.util.List;

import com.augmentum.dao.RoleDao;
import com.augmentum.dao.impl.RoleDaoImpl;
import com.augmentum.model.Role;
import com.augmentum.service.RoleService;

public class RoleServiceImpl implements RoleService{

    private RoleDao roleDao = new RoleDaoImpl();

    @Override
    public List<Role> findRoleList() {
        return roleDao.findRoleList();
    }

}
