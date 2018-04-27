package com.augmentum.exception;

import com.augmentum.util.MessageUtil;


public class BasicException extends RuntimeException {

    private static final long serialVersionUID = 252054923623801781L;

    private String errCode;

    public BasicException(String errMsg) {
        super(errMsg);
        setErrCode(MessageUtil.INTERNAL_SERVER_ERROR);
    }

    public BasicException(String errCode, String errMsg) {
        super(errMsg);
        setErrCode(errCode);
    }

    public BasicException(String errCode, String errMsg, Throwable cause) {
        super(errMsg, cause);
        setErrCode(errCode);
    }

    public String getErrCode() {
        return errCode;
    }

    public void setErrCode(String errCode) {
        this.errCode = errCode;
    }

}
