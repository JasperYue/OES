package com.augmentum.model;

import java.io.Serializable;
import java.sql.Timestamp;

public class Question implements Serializable{

    private static final long serialVersionUID = -8064054993636994575L;

    private Integer id;

    private String num;

    private String title;

    private String itemA;

    private String itemB;

    private String itemC;

    private String itemD;

    private int answer;

    private int delMark;

    private int referMark;

    private Timestamp createTime;

    private Timestamp updateTime;

    public Question() {
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

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getItemA() {
        return itemA;
    }

    public void setItemA(String itemA) {
        this.itemA = itemA;
    }

    public String getItemB() {
        return itemB;
    }

    public void setItemB(String itemB) {
        this.itemB = itemB;
    }

    public String getItemC() {
        return itemC;
    }

    public void setItemC(String itemC) {
        this.itemC = itemC;
    }

    public String getItemD() {
        return itemD;
    }

    public void setItemD(String itemD) {
        this.itemD = itemD;
    }

    public int getAnswer() {
        return answer;
    }

    public void setAnswer(int answer) {
        this.answer = answer;
    }

    public int getDelMark() {
        return delMark;
    }

    public void setDelMark(int delMark) {
        this.delMark = delMark;
    }

    @Override
    public String toString() {
        return "Question [id=" + id + ", num=" + num + ", title=" + title + ", itemA=" + itemA + ", itemB=" + itemB
                + ", itemC=" + itemC + ", itemD=" + itemD + ", answer=" + answer + ", delMark=" + delMark
                + ", referMark=" + referMark + ", createTime=" + createTime + ", updateTime=" + updateTime + "]";
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

    public int getReferMark() {
        return referMark;
    }

    public void setReferMark(int referMark) {
        this.referMark = referMark;
    }

}
