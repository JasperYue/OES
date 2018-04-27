package com.augmentum.controller;

import org.apache.log4j.Logger;
import org.springframework.dao.DataAccessException;
import org.springframework.web.servlet.ModelAndView;

import com.augmentum.Constants;
import com.augmentum.WebContext;
import com.augmentum.exception.DBException;
import com.augmentum.exception.ParamException;
import com.augmentum.exception.ServiceException;

public class BaseController {

    private final Logger logger = Logger.getLogger(BaseController.class);

    protected void setRequestScopeAttribute(RuntimeException e, ModelAndView modelAndView) {

        logger.info(WebContext.getContext().getVal(Constants.USER) + e.getMessage(), e);
        if (e instanceof ParamException ) {
            ParamException paramException = (ParamException) e;
            if (((ParamException) e).getErrMsgMap() != null) {
                modelAndView.addObject(Constants.ERROR_MESSAGE, paramException.getErrMsgMap());
            }else {
                modelAndView.addObject(Constants.TIP_MESSAGE, paramException.getMessage());
            }
        } else if (e instanceof DBException) {
            DBException dbException = (DBException) e;
            modelAndView.addObject(Constants.TIP_MESSAGE, dbException.getMessage());
        } else if (e instanceof DataAccessException) {
            DataAccessException dataAccessException = (DataAccessException) e;
            modelAndView.addObject(Constants.TIP_MESSAGE, dataAccessException.getMessage());
        } else if (e instanceof ServiceException) {
            ServiceException serviceException = (ServiceException) e;
            modelAndView.addObject(Constants.TIP_MESSAGE, serviceException.getMessage());
        }
    }

}
