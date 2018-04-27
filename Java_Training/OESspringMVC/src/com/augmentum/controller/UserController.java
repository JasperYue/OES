package com.augmentum.controller;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CookieValue;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.augmentum.Constants;
import com.augmentum.WebContext;
import com.augmentum.model.User;
import com.augmentum.service.UserService;
import com.augmentum.util.StringUtil;
import com.augmentum.util.WebUtil;

@Controller
@RequestMapping(Constants.APP_URL_USER_PREFIX)
public class UserController extends BaseController {

    private final Logger logger = Logger.getLogger(UserController.class);
    @Autowired
    private UserService userService;

    public void setUserService(UserService userService) {
        this.userService = userService;
    }

    @RequestMapping(value = "/login", method = RequestMethod.GET)
    public ModelAndView toLogin(@RequestParam(value = Constants.GO, defaultValue = "") String go) {

        ModelAndView modelAndView = new ModelAndView();
        User user = (User) ((HttpSession) WebContext.getContext().getVal(Constants.APP_CONTEXT_SESSION)).getAttribute(Constants.USER);
        if (user == null) {
            modelAndView.addObject(Constants.GO, go);
            modelAndView.setViewName(Constants.LOGIN_PAGE);
        } else {
            logger.info(StringUtil.getFullPath(Constants.QUESTION_LIST));
            modelAndView.setView(new RedirectView(StringUtil.getFullPath(Constants.QUESTION_LIST)));
        }

        return modelAndView;

    }

    @RequestMapping(value = "/login", method = RequestMethod.POST)
    public ModelAndView login(
                              User userRequest, HttpServletResponse response,
                              @RequestParam(value = Constants.REMEMBER, defaultValue = "") String isAdd,
                              @RequestParam(value = Constants.GO, defaultValue = "") String go,
                              @RequestParam(value = Constants.QUERY_STRING, defaultValue = "") String queryString,
                              @CookieValue(value= Constants.NAMECOOKIE, required = false) Cookie nameCookie,
                              @CookieValue(value= Constants.PWDCOOKIE, required = false) Cookie pwdCookie
                              ) throws ServletException, IOException {

        ModelAndView modelAndView = new ModelAndView();

        /** Whether password encrypt by MD5 */
        boolean MD5flag = WebUtil.isPwdEncryptByMD5(pwdCookie, userRequest);

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
            HttpSession session = (HttpSession) WebContext.getContext().getVal(Constants.APP_CONTEXT_SESSION);

            session.setAttribute(Constants.APP_CONTEXT_USER, user);

            WebContext.getContext().addKeyVal(Constants.APP_CONTEXT_USER, user);

            /** validate whether to use cookie */
            if (!StringUtil.isEmpty(isAdd)) {
                if (StringUtil.isEquals(String.valueOf(Constants.STATUS_ONE), isAdd)) {
                    /** Add cookie to local */
                    WebUtil.addCooike(user, nameCookie, pwdCookie, response);
                } else if (StringUtil.isEquals(String.valueOf(Constants.STATUS_ZERO), isAdd)) {
                    /** Delete cookie at local */
                    WebUtil.delCooike(nameCookie, pwdCookie, response);
                }
            }

            if (!StringUtil.isEmpty(queryString)) {
                if (queryString.startsWith("#")) {
                    queryString = queryString.substring(1);
                }
                go = go + "?" + queryString;
            }

            if (go.startsWith(Constants.APP_URL_USER_PREFIX + "/logout")) {
                go = Constants.NO_CONTENTS;
            }

            //page/question/toQuestionList
            String uri = StringUtil.isEmpty(go) ? StringUtil.getFullPath(Constants.QUESTION_LIST) : WebContext.getContextPath() + "/" +go;

            modelAndView.setView(new RedirectView(uri));

            logger.info(user.getName() + " login successfully");

        } catch (RuntimeException e) {
            /** Handle all custom exception here*/
            setRequestScopeAttribute(e, modelAndView);
            modelAndView.setViewName(Constants.LOGIN_PAGE);
        }
        return modelAndView;

    }

    @RequestMapping(value = "/logout", method = RequestMethod.GET)
    public ModelAndView logout() {

        HttpSession session = (HttpSession) WebContext.getContext().getVal(Constants.APP_CONTEXT_SESSION);
        User user = (User) session.getAttribute(Constants.USER);
        ModelAndView modelAndView = new ModelAndView();
        if (user != null) {
            logger.info(user.getName() + " logout");
            session.invalidate();
        }
        modelAndView.setView(new RedirectView(StringUtil.getFullPath(Constants.TO_LOGIN)));
        return modelAndView;

    }

}
