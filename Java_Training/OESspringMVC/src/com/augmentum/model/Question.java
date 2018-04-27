package com.augmentum.model;

import java.io.Serializable;
import java.sql.Timestamp;

import org.codehaus.jackson.annotate.JsonIgnore;

import com.augmentum.util.WebUtil;

public class Question implements Serializable {

    private static final long serialVersionUID = -8064054993636994575L;

    public static final String QUESTION = "Question";
    public static final String ID = "id";
    public static final String NUM = "num";
    public static final String TITLE = "title";
    public static final String ITEM_A = "itemA";
    public static final String ITEM_B = "itemB";
    public static final String ITEM_C = "itemC";
    public static final String ITEM_D = "itemD";
    public static final String ANSWER = "answer";
    public static final String DEL_MARK = "delMark";
    public static final String REFER_MARK = "referMark";
    public static final String CREATE_TIME = "createTime";
    public static final String UPDATE_TIME = "updateTime";

    private Integer id;

    private String num;

    private String title;

    private String itemA;

    private String itemB;

    private String itemC;

    private String itemD;

    private int answer;
    @JsonIgnore
    private int delMark;
    @JsonIgnore
    private int referMark;
    @JsonIgnore
    private Timestamp createTime;
    @JsonIgnore
    private Timestamp updateTime;

    public Question() {

    }

    public Question(String title, String itemA, String itemB, String itemC, String itemD, int answer) {
        this.title = title;
        this.itemA = itemA;
        this.itemB = itemB;
        this.itemC = itemC;
        this.itemD = itemD;
        this.answer = answer;
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
        this.title = WebUtil.transferred(title);
    }

    public String getItemA() {
        return itemA;
    }

    public void setItemA(String itemA) {
        this.itemA = WebUtil.transferred(itemA);
    }

    public String getItemB() {
        return itemB;
    }

    public void setItemB(String itemB) {
        this.itemB = WebUtil.transferred(itemB);
    }

    public String getItemC() {
        return itemC;
    }

    public void setItemC(String itemC) {
        this.itemC = WebUtil.transferred(itemC);
    }

    public String getItemD() {
        return itemD;
    }

    public void setItemD(String itemD) {
        this.itemD = WebUtil.transferred(itemD);
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

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result + answer;
        result = prime * result + ((createTime == null) ? 0 : createTime.hashCode());
        result = prime * result + delMark;
        result = prime * result + ((id == null) ? 0 : id.hashCode());
        result = prime * result + ((itemA == null) ? 0 : itemA.hashCode());
        result = prime * result + ((itemB == null) ? 0 : itemB.hashCode());
        result = prime * result + ((itemC == null) ? 0 : itemC.hashCode());
        result = prime * result + ((itemD == null) ? 0 : itemD.hashCode());
        result = prime * result + ((num == null) ? 0 : num.hashCode());
        result = prime * result + referMark;
        result = prime * result + ((title == null) ? 0 : title.hashCode());
        result = prime * result + ((updateTime == null) ? 0 : updateTime.hashCode());
        return result;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        Question other = (Question) obj;
        if (answer != other.answer)
            return false;
        if (createTime == null) {
            if (other.createTime != null)
                return false;
        } else if (!createTime.equals(other.createTime))
            return false;
        if (delMark != other.delMark)
            return false;
        if (id == null) {
            if (other.id != null)
                return false;
        } else if (!id.equals(other.id))
            return false;
        if (itemA == null) {
            if (other.itemA != null)
                return false;
        } else if (!itemA.equals(other.itemA))
            return false;
        if (itemB == null) {
            if (other.itemB != null)
                return false;
        } else if (!itemB.equals(other.itemB))
            return false;
        if (itemC == null) {
            if (other.itemC != null)
                return false;
        } else if (!itemC.equals(other.itemC))
            return false;
        if (itemD == null) {
            if (other.itemD != null)
                return false;
        } else if (!itemD.equals(other.itemD))
            return false;
        if (num == null) {
            if (other.num != null)
                return false;
        } else if (!num.equals(other.num))
            return false;
        if (referMark != other.referMark)
            return false;
        if (title == null) {
            if (other.title != null)
                return false;
        } else if (!title.equals(other.title))
            return false;
        if (updateTime == null) {
            if (other.updateTime != null)
                return false;
        } else if (!updateTime.equals(other.updateTime))
            return false;
        return true;
    }

    @Override
    public String toString() {
        return "Question [id=" + id + ", num=" + num + ", title=" + title + ", itemA=" + itemA + ", itemB=" + itemB
                + ", itemC=" + itemC + ", itemD=" + itemD + ", answer=" + answer + ", delMark=" + delMark
                + ", referMark=" + referMark + ", createTime=" + createTime + ", updateTime=" + updateTime + "]";
    }

}
