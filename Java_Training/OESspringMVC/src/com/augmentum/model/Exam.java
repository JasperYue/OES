package com.augmentum.model;

import java.io.Serializable;
import java.sql.Timestamp;

import org.codehaus.jackson.annotate.JsonIgnore;

import com.augmentum.util.WebUtil;

public class Exam implements Serializable {

    private static final long serialVersionUID = 56757563987543653L;

    public static final String EXAM = "Exam";
    public static final String ID = "id";
    public static final String NUM = "num";
    public static final String NAME = "name";
    public static final String DESCRIPTION = "description";
    public static final String SINGLE_SCORE = "singleScore";
    public static final String TOTAL_SCORE = "totalScore";
    public static final String PASS_CRITERIA = "passCriteria";
    public static final String NEED_QUANTITY = "needQuantity";
    public static final String FACT_QUANTITY = "factQuantity";
    public static final String EFFECTIVE_TIME = "effectiveTime";
    public static final String DURATION = "duration";
    public static final String CREATOR = "creator";
    public static final String ANSWER_STR = "answerStr";
    public static final String CREATE_TIME = "createTime";
    public static final String UPDATE_TIME = "updateTime";
    public static final String STATUS = "status";

    private Integer id;

    private String num;

    private String name;

    private String description;
    @JsonIgnore
    private float singleScore;
    @JsonIgnore
    private float totalScore;
    @JsonIgnore
    private int passCriteria;

    private int needQuantity;

    private int factQuantity;

    private String effectiveTime;

    private int duration;

    private String creator;
    @JsonIgnore
    private String answerStr;
    @JsonIgnore
    private Timestamp createTime;
    @JsonIgnore
    private Timestamp updateTime;

    private int status;

    public Exam() {

    }

    public Exam(String name, String description, float singleScore, float totalScore, int passCriteria,
            int needQuantity, String effectiveTime, int duration) {
        this.name = name;
        this.description = description;
        this.singleScore = singleScore;
        this.totalScore = totalScore;
        this.passCriteria = passCriteria;
        this.needQuantity = needQuantity;
        this.effectiveTime = effectiveTime;
        this.duration = duration;
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
        this.name = WebUtil.transferred(name);
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = WebUtil.transferred(description);
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
