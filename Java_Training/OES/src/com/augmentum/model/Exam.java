package com.augmentum.model;

import java.io.Serializable;
import java.sql.Timestamp;

public class Exam implements Serializable{

    private static final long serialVersionUID = 56757563987543653L;

    private Integer id;

    private String num;

    private String name;

    private String description;

    private float singleScore;

    private float totalScore;

    private int passCriteria;

    private int needQuantity;

    private int factQuantity;

    private String effectiveTime;

    private int duration;

    private String creator;

    private String answerStr;

    private Timestamp createTime;

    private Timestamp updateTime;

    private int status;

    public Exam() {

    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getNum() {
        return num;
    }

    public void setNum(String num) {
        this.num = num;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public float getSingleScore() {
        return singleScore;
    }

    public void setSingleScore(float singleScore) {
        this.singleScore = singleScore;
    }

    public float getTotalScore() {
        return totalScore;
    }

    public void setTotalScore(float totalScore) {
        this.totalScore = totalScore;
    }

    public int getPassCriteria() {
        return passCriteria;
    }

    public void setPassCriteria(int passCriteria) {
        this.passCriteria = passCriteria;
    }

    public int getNeedQuantity() {
        return needQuantity;
    }

    public void setNeedQuantity(int needQuantity) {
        this.needQuantity = needQuantity;
    }

    public int getFactQuantity() {
        return factQuantity;
    }

    public void setFactQuantity(int factQuantity) {
        this.factQuantity = factQuantity;
    }

    public String getEffectiveTime() {
        return effectiveTime;
    }

    public void setEffectiveTime(String effectiveTime) {
        this.effectiveTime = effectiveTime;
    }

    public int getDuration() {
        return duration;
    }

    public void setDuration(int duration) {
        this.duration = duration;
    }

    public String getCreator() {
        return creator;
    }

    public void setCreator(String creator) {
        this.creator = creator;
    }

    public String getAnswerStr() {
        return answerStr;
    }

    public void setAnswerStr(String answerStr) {
        this.answerStr = answerStr;
    }

    public Timestamp getCreateTime() {
        return createTime;
    }

    public void setCreateTime(Timestamp createTime) {
        this.createTime = createTime;
    }

    public Timestamp getUpdateTime() {
        return updateTime;
    }

    public void setUpdateTime(Timestamp updateTime) {
        this.updateTime = updateTime;
    }

    public int getStatus() {
        return status;
    }

    public void setStatus(int status) {
        this.status = status;
    }

}
