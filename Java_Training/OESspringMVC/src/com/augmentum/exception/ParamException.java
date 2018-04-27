package com.augmentum.exception;

import java.util.Map;

/**
 * throw the exception of data formatter etc
 * @author Jasper.yue
 *
 */
public class ParamException extends BasicException {

    private static final long serialVersionUID = 1L;

    /** use to save error message */
    private Map<String, String> errMsgMap;

    public ParamException(String errMsg) {
        super(errMsg);
    }

    public ParamException(String errCode, String errMsg) {
        super(errCode, errMsg);
    }

    public ParamException(String errCode, String errMsg, Map<String, String> errMsgMap) {
        super(errCode, errMsg);
        setErrMsgMap(errMsgMap);
    }

    public Map<String, String> getErrMsgMap() {
        return errMsgMap;
    }

    public void setErrMsgMap(Map<String, String> errMsgMap) {
        this.errMsgMap = errMsgMap;
    }

}
