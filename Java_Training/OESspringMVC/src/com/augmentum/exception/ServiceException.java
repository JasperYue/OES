package com.augmentum.exception;

/**
 * throw the business exception
 * @author Jasper.yue
 *
 */
public class ServiceException extends BasicException {

    private static final long serialVersionUID = -3520233411793405943L;

    public ServiceException(String errMsg) {
        super(errMsg);
    }

    public ServiceException(String errCode, String errMsg) {
        super(errCode, errMsg);
    }

    public ServiceException(String errCode, String errMsg, Throwable cause) {
        super(errCode, errMsg, cause);
    }
}
