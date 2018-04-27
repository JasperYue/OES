package com.augmentum.util;

import java.io.IOException;
import java.security.MessageDigest;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;

import com.augmentum.Constants;
import com.augmentum.model.User;
import common.ModelAndView;

public final class WebUtil {

    public static boolean isCookieExist(Cookie[] cookies, String cookieName){
        if (cookies != null) {
            for (Cookie cookie : cookies) {
                if (StringUtil.isEquals(cookie.getName(), cookieName)) {
                    return true;
                }
            }
        }
        return false;
    }

    public static void delCooike(Cookie[] cookies, ModelAndView modelAndView) throws ServletException, IOException {
        if (cookies != null) {
            for (Cookie cookie : cookies) {
                if (StringUtil.isEquals(cookie.getName(), Constants.NAMECOOKIE) ||
                        StringUtil.isEquals(cookie.getName(), Constants.PWDCOOKIE)) {
                    cookie.setMaxAge(0);
                    modelAndView.getResponseMap().put(cookie.getName(), cookie);
                }
            }
        }
    }

    public static void addCooike(User user, Cookie[] cookies, ModelAndView modelAndView) throws ServletException, IOException {
        /**
         * If Cookies already exists in local, then do nothing.
         * If not exists, then add.
         */
        if(!(WebUtil.isCookieExist(cookies, Constants.NAMECOOKIE) &&
                WebUtil.isCookieExist(cookies, Constants.PWDCOOKIE))) {
            Cookie nameCookie = new Cookie(Constants.NAMECOOKIE, user.getName());
            Cookie pwdCookie = new Cookie(Constants.PWDCOOKIE, user.getPassword());

            // Pass 1: Set the LifeCircle of cookie with 3 days
            nameCookie.setMaxAge(60 * 60 * 24 * 3);
            pwdCookie.setMaxAge(60 * 60 * 24 * 3);
            // Pass 2: Set the valid path
            //nameCookie.setPath(request.getContextPath());
            //pwdCookie.setPath(request.getContextPath());

            modelAndView.getResponseMap().put(Constants.NAMECOOKIE, nameCookie);
            modelAndView.getResponseMap().put(Constants.PWDCOOKIE, pwdCookie);

        }

    }

    public static boolean isPwdEncryptByMD5(Cookie[] cookies, User userRequest) {

        if (StringUtil.isEmpty(userRequest.getPassword())) {
            return true;
        }

        if (cookies != null) {
            for (Cookie cookie : cookies) {
                String cookieName = cookie.getName();
                if(cookieName.equals(Constants.PWDCOOKIE)) {
                    String cookieVal = cookie.getValue();
                    if (userRequest.getPassword().equals(cookieVal)) {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    /**
     * String -> byte[] Using MD5
     * @param source
     * @return
     */
    public static byte[] encode2bytes(String source) {
        byte[] result = null;

        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            md.reset();
            md.update(source.getBytes("UTF-8"));
            result = md.digest();
        } catch (Exception e) {
        }

        return result;
    }

    /**
     * String -> 32Hex Using MD5
     * @param source
     * @return
     */
    public static String encode2hex(String source) {
        byte[] data =encode2bytes(source);

        StringBuffer hexString = new StringBuffer();
        for (int i = 0; i < data.length; i++) {
            String hex = Integer.toHexString(0xff & data[i]);
            if (hex.length() == 1) {
                hexString.append("0");
            }
            hexString.append(hex);
        }

        return hexString.toString();
    }

    /**
     * validate this string is matched
     * @param unknown
     * @param okHex
     * @return
     */
    public static boolean validate(String unknown, String okHex) {
        return okHex.equals(encode2hex(unknown));
    }

}
