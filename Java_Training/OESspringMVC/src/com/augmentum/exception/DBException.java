package com.augmentum.exception;

public class DBException extends BasicException {

    private static final long serialVersionUID = 4773407595065456743L;

    public DBException(String errMsg) {
        super(errMsg);
    }

    public DBException(String errCode, String errMsg) {
        super(errCode, errMsg);
    }

    public DBException(String errCode, String errMsg, Throwable cause) {
        super(errCode, errMsg, cause);
    }

}
