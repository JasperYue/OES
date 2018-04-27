package com.augmentum.util;

import com.augmentum.Constants;

/**
 * Packaging the criterion of fuzzy search
 */
public class FuzzyCriterion<T> {

    public static final String TITLE = "title";
    public static final String ORDER_FIELD = "orderField";
    public static final String TIME_BEGIN = "timeBegin";
    public static final String TIME_END = "timeEnd";

    /** FuzzyCriterion contains the object of page */
    private Page<T> page;

    /** Title or Name */
    private String title;

    /** Order by condition */
    private String orderField;

    /** The point of begin time */
    private String timeBegin;

    /** The point of end time */
    private String timeEnd;

    /** Constructor 1 : use to fuzzy search by title or name */
    public FuzzyCriterion(String orderField, String title, Page<T> page) {
        setPage(page);
        setTitle(title);
        setOrderField(orderField);
    }

    /** Constructor 2 : use to fuzzy search by range of time */
    public FuzzyCriterion(Page<T> page, String title, String orderField, String timeBegin, String timeEnd) {
        setPage(page);
        setTitle(title);
        setOrderField(orderField);
        setTimeBegin(timeBegin);
        setTimeEnd(timeEnd);
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        if (StringUtil.isEmpty(title)) {
            this.title = "%%";
        } else {
            title = title.trim();
            title = title.replaceAll("\\\\", "\\\\\\\\");
            title = title.replaceAll("\\%", "\\\\%");
            title = title.replaceAll("\\_", "\\\\_");
            title = WebUtil.transferred(title);
            this.title = "%" + title + "%";
        }
    }

    public String getTimeBegin() {
        return timeBegin;
    }

    public void setTimeBegin(String timeBegin) {
        if (StringUtil.isEmpty(timeBegin)) {
            timeBegin = Constants.TIME_BEGIN;
        }
        this.timeBegin = timeBegin;
    }

    public String getTimeEnd() {
        return timeEnd;
    }

    public void setTimeEnd(String timeEnd) {
        if (StringUtil.isEmpty(timeEnd)) {
            timeEnd = Constants.TIME_END;
        }
        this.timeEnd = timeEnd;
    }

    public Page<T> getPage() {
        return page;
    }

    public void setPage(Page<T> page) {
        this.page = page;
    }

    public String getOrderField() {
        return orderField;
    }

    public void setOrderField(String orderField) {
        this.orderField = orderField;
    }

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result + ((orderField == null) ? 0 : orderField.hashCode());
        result = prime * result + ((page == null) ? 0 : page.hashCode());
        result = prime * result + ((timeBegin == null) ? 0 : timeBegin.hashCode());
        result = prime * result + ((timeEnd == null) ? 0 : timeEnd.hashCode());
        result = prime * result + ((title == null) ? 0 : title.hashCode());
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
        FuzzyCriterion<?> other = (FuzzyCriterion<?>) obj;
        if (orderField == null) {
            if (other.orderField != null)
                return false;
        } else if (!orderField.equals(other.orderField))
            return false;
        if (page == null) {
            if (other.page != null)
                return false;
        } else if (!page.equals(other.page))
            return false;
        if (timeBegin == null) {
            if (other.timeBegin != null)
                return false;
        } else if (!timeBegin.equals(other.timeBegin))
            return false;
        if (timeEnd == null) {
            if (other.timeEnd != null)
                return false;
        } else if (!timeEnd.equals(other.timeEnd))
            return false;
        if (title == null) {
            if (other.title != null)
                return false;
        } else if (!title.equals(other.title))
            return false;
        return true;
    }

}
