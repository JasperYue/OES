package com.augmentum.controller;

import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import org.apache.commons.beanutils.BeanUtils;

import com.augmentum.Constants;
import com.augmentum.exception.BasicException;
import com.augmentum.exception.DBException;
import com.augmentum.exception.ParamException;
import com.augmentum.exception.ServiceException;
import com.augmentum.util.MessageUtil;
import common.ModelAndView;

public class ExceptionHandler{

    protected void setRequestScopeAttribute(BasicException e, ModelAndView modelAndView) {
        if (e instanceof DBException) {
            DBException dbException = (DBException) e;
            modelAndView.setAttrAtRequest(Constants.TIP_MESSAGE, dbException.getMessage());
        } else if (e instanceof ParamException) {
            ParamException paramException = (ParamException) e;
            if (((ParamException) e).getErrMsgMap() != null) {
                modelAndView.setAttrAtRequest(Constants.ERROR_MESSAGE, paramException.getErrMsgMap());
            }else {
                modelAndView.setAttrAtRequest(Constants.TIP_MESSAGE, paramException.getMessage());
            }
        } else if (e instanceof ServiceException) {
            ServiceException serviceException = (ServiceException) e;
            modelAndView.setAttrAtRequest(Constants.TIP_MESSAGE, serviceException.getMessage());
        }
    }

    /**
     * Reflect the data from request into specific object
     * @return an object transfer from request
     */
    public <T> T request2Bean(Map<String, Object> requestMap, Class<T> clazz){
        try {
            T obj = clazz.newInstance();

            requestMap.remove("COOKIES");

            Set<Entry<String, Object>> requestSet = requestMap.entrySet();
            for(Entry<String, Object> request : requestSet) {
                String name = request.getKey();
                String value = (String) request.getValue();
                try {
                    BeanUtils.setProperty(obj, name, value);
                } catch (Exception ex) {
                }
            }
            return obj;
        } catch (Exception e) {
            throw new ServiceException(MessageUtil.REFLECT_REQUEST2OBJ_ERROR,
                    MessageUtil.buildMessage(MessageUtil.REFLECT_REQUEST2OBJ_ERROR));
        }
    }

}
