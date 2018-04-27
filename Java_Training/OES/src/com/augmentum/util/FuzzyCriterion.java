package com.augmentum.util;


/**
 * Packaging the criterion of fuzzy search
 * @author Jasper.yue
 *
 */
public class FuzzyCriterion<T> {

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
            title = title.replaceAll("\\%", "");
            title = title.replaceAll("\\\\", "");
            title = title.replaceAll("\\_", "\\\\_");
            this.title = "%" + title + "%";
        }
    }

    public String getTimeBegin() {
        return timeBegin;
    }

    public void setTimeBegin(String timeBegin) {
        if (StringUtil.isEmpty(timeBegin)) {
            timeBegin = "2010-01-01";
        }
        this.timeBegin = timeBegin;
    }

    public String getTimeEnd() {
        return timeEnd;
    }

    public void setTimeEnd(String timeEnd) {
        if (StringUtil.isEmpty(timeEnd)) {
            timeEnd = "2050-01-01";
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
}
