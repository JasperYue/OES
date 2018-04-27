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

        while (paginationList.size() > 5) {
            if (currentPage - 1 > maxPage - currentPage) {
                paginationList.remove(0);
            } else {
                paginationList.remove(paginationList.size() - 1);
            }
        }

        if (maxPage >= 5) {
            while (paginationList.size() < 5) {
                if (currentPage - 1 > maxPage - currentPage) {
                    paginationList.add(0, paginationList.get(0) - 1);
                } else {
                    paginationList.add(paginationList.get(paginationList.size() - 1) + 1);
                }
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
        return getTotalItem()%getPageSize() == 0
                ? getTotalItem()/getPageSize()
                : getTotalItem()/getPageSize() + 1;
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
            pageSize = 5;
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

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result + ((pageList == null) ? 0 : pageList.hashCode());
        result = prime * result + pageNo;
        result = prime * result + pageSize;
        result = prime * result + ((paginationList == null) ? 0 : paginationList.hashCode());
        result = prime * result + totalItem;
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
        Page<?> other = (Page<?>) obj;
        if (pageList == null) {
            if (other.pageList != null)
                return false;
        } else if (!pageList.equals(other.pageList))
            return false;
        if (pageNo != other.pageNo)
            return false;
        if (pageSize != other.pageSize)
            return false;
        if (paginationList == null) {
            if (other.paginationList != null)
                return false;
        } else if (!paginationList.equals(other.paginationList))
            return false;
        if (totalItem != other.totalItem)
            return false;
        return true;
    }

}