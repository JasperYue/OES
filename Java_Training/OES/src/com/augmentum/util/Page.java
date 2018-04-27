package com.augmentum.util;

import java.util.ArrayList;
import java.util.List;

public class Page<T> {

    /** Current num of page */
    private int pageNo;

    /** The size of items per page */
    private int pageSize;

    /** The totalItem in database */
    private int totalItem;

    /** The itemList per page */
    private List<T> pageList;

    private List<Integer> paginationList;

    public Page(int pageNo) {
        this.pageNo = pageNo;
    }

    public Page(int pageNo, int pageSize) {
        this.pageNo = pageNo;
        this.pageSize = pageSize;
    }

    /** Get pagination */
    public List<Integer> getPaginationList() {
        paginationList = new ArrayList<>();
        int currentPage = getPageNo();
        int maxPage = getTotalPage();

        for (int i = currentPage - 3; i < currentPage + 3; i++) {
            paginationList.add(i);
        }
        for (int i = 0; i < paginationList.size(); i++) {
            if (paginationList.get(i) <= 0 || paginationList.get(i) > maxPage) {
                paginationList.remove(i);
                i--;
            }
        }

        return paginationList;
    }

    /** Get previous page */
    public int getPrevPage() {
        return isHasPrev() ? getPageNo() - 1 : 1 ;
    }

    /** Get next page */
    public int getNextPage() {
        return isHasNext() ? getPageNo() + 1 : getTotalPage() ;
    }

    /** Is has previous page */
    public boolean isHasPrev() {
        return getPageNo() > 1 ? true : false ;
    }

    /** Is has next page */
    public boolean isHasNext() {
        return getPageNo() < getTotalPage() ? true : false ;
    }

    /** How many page do this table have */
    public int getTotalPage() {
        return getTotalItem()%getPageSize() == 0 ? getTotalItem()/getPageSize() : getTotalItem()/getPageSize() + 1;
    }

    public int getPageNo() {
        if (pageNo <= 0 || getTotalPage() == 0) {
            pageNo = 1;
        } else if (pageNo > getTotalPage()) {
            pageNo = getTotalPage();
        }
        return pageNo;
    }

    public void setPageNo(int pageNo) {
        this.pageNo = pageNo;
    }

    public int getPageSize() {
        if (pageSize <=0) {
            pageSize = 3;
        } else if (pageSize > 10) {
            pageSize = 10;
        }
        return pageSize;
    }

    public void setPageSize(int pageSize) {
        this.pageSize = pageSize;
    }

    public int getTotalItem() {
        return totalItem;
    }

    public void setTotalItem(int totalItem) {
        this.totalItem = totalItem;
    }

    public List<T> getPageList() {
        return pageList;
    }

    public void setPageList(List<T> pageList) {
        this.pageList = pageList;
    }

}