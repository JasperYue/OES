package com.augmentum.controller;

import java.io.IOException;
import java.util.Map;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;

import com.augmentum.Constants;
import com.augmentum.exception.BasicException;
import com.augmentum.model.User;
import com.augmentum.service.UserService;
import com.augmentum.util.StringUtil;
import com.augmentum.util.WebUtil;
import common.ModelAndView;

public class UserController extends ExceptionHandler{

    private UserService userService;

    public void setUserService(UserService userService) {
        this.userService = userService;
    }

    public ModelAndView toLogin(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) {

        ModelAndView modelAndView = new ModelAndView();
        User user = (User) sessionMap.get(Constants.USER);
        if (user == null) {
            String go = (String) requestMap.get("go");
            if (StringUtil.isEmpty(go)) {
                go = "";
            }
            modelAndView.setAttrAtRequest("go", go);
            modelAndView.setView("needLogin");
        } else {
            modelAndView.setRedirect(true);
            modelAndView.setView("hadLogin");
        }

        return modelAndView;
    }

    public ModelAndView login(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) throws ServletException, IOException {
        Cookie[] cookies = (Cookie[]) requestMap.get("COOKIES");
        ModelAndView modelAndView = new ModelAndView();

        User userRequest = request2Bean(requestMap, User.class);

        /** Whether password encrypt by MD5 */
        boolean MD5flag = WebUtil.isPwdEncryptByMD5(cookies, userRequest);

        /*
         * If password is empty, return true and let it go.[Service raise exception]
         * If password not encrypted by MD5, then encrypt and set it in user
         * Use this user[Encrypt password] to match the user in database.
         */
        if (!MD5flag) {
            userRequest.setPassword(WebUtil.encode2hex(userRequest.getPassword()));
        }

        try {
            User user = userService.login(userRequest);

            /** Set attribute at session scope*/
            modelAndView.setAttrAtSession(Constants.USER, user);

            /** validate whether to use cookie */
            String isAdd = (String) requestMap.get(Constants.REMEMBER);
            if (!StringUtil.isEmpty(isAdd)) {
                if (StringUtil.isEquals(String.valueOf(Constants.STATUS_ONE), isAdd)) {
                    /** Add cookie to local */
                    WebUtil.addCooike(user, cookies, modelAndView);
                } else if (StringUtil.isEquals(String.valueOf(Constants.STATUS_ZERO), isAdd)) {
                    /** Delete cookie at local */
                    WebUtil.delCooike(cookies, modelAndView);
                }
            }

            String go = (String) requestMap.get("go");

            String queryString = (String) requestMap.get("queryString");

            if (!StringUtil.isEmpty(queryString)) {
                if (queryString.startsWith("#")) {
                    queryString = queryString.substring(1);
                }
                go = go + "?" + queryString;
            }

            modelAndView.setRedirect(true);

            String uri = StringUtil.isEmpty(go) ? "success" : go;

            modelAndView.setView(uri);

        } catch (BasicException e) {
            /** Handle all custom exception here*/
            setRequestScopeAttribute(e, modelAndView);
            modelAndView.setView("error");
        }
        return modelAndView;
    }

    public ModelAndView logout(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) {

        User user = (User) sessionMap.get(Constants.USER);
        ModelAndView modelAndView = new ModelAndView();
        if (user != null) {
            // 1.session.invalidate();
            modelAndView.setAttrAtSession(Constants.USER, null);
        }
        modelAndView.setRedirect(true);
        modelAndView.setView("success");
        return modelAndView;
    }

}
