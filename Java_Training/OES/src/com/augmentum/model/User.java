package com.augmentum.model;

import java.io.Serializable;
import java.util.Date;

/**
 * User entity
 * @author Jasper.yue
 *
 */
public class User implements Serializable{

    private static final long serialVersionUID = 4841461630873069434L;

    /** The id of user */
    private Integer id;

    /** The name of user*/
    private String name;

    /** The password of user */
    private String password;

    /** The sex of user */
    private String gender;

    /** The telphone of user */
    private String tel;

    /** The email of user */
    private String email;

    /** The role of user */
    private int roleId;

    /** Whether user is deleted */
    private int delMark;

    private Date createTime;

    private Date updateTime;

    public User() {

    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public String getTel() {
        return tel;
    }

    public void setTel(String tel) {
        this.tel = tel;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public int getRoleId() {
        return roleId;
    }

    public void setRoleId(int roleId) {
        this.roleId = roleId;
    }

    public int getDelMark() {
        return delMark;
    }

    public void setDelMark(int delMark) {
        this.delMark = delMark;
    }

    public Date getCreateTime() {
        return createTime;
    }

    public void setCreateTime(Date createTime) {
        this.createTime = createTime;
    }

    public Date getUpdateTime() {
        return updateTime;
    }

    public void setUpdateTime(Date updateTime) {
        this.updateTime = updateTime;
    }

}
