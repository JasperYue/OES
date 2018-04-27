package com.augmentum.model;

import java.io.Serializable;

public class Role implements Serializable{

    private static final long serialVersionUID = -2084301566915717288L;

    /** The id of role */
    private Integer id;

    /** The name of role */
    private String name;

    public Role() {

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

}
