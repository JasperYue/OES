package com.augmentum.util;

import java.io.IOException;
import java.security.MessageDigest;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletResponse;

import com.augmentum.Constants;
import com.augmentum.model.User;

public final class WebUtil {

    public static void delCooike(Cookie nameCookie, Cookie pwdCookie, HttpServletResponse response) {
        if (nameCookie != null) {
            nameCookie.setMaxAge(0);
            response.addCookie(nameCookie);
        }
        if (pwdCookie !=null) {
            pwdCookie.setMaxAge(0);
            response.addCookie(pwdCookie);
        }
    }

    public static void addCooike(User user, Cookie nameCookieFromClient, Cookie pwdCookieFromClient, HttpServletResponse response) throws ServletException, IOException {
        /**
         * If Cookies already exists in local, then do nothing.
         * If not exists, then add.
         */
        if(nameCookieFromClient == null || pwdCookieFromClient == null) {
            Cookie nameCookie = new Cookie(Constants.NAMECOOKIE, user.getName());
            Cookie pwdCookie = new Cookie(Constants.PWDCOOKIE, user.getPassword());

            // Pass 1: Set the LifeCircle of cookie with 3 days
            nameCookie.setMaxAge(60 * 60 * 24 * 3);
            pwdCookie.setMaxAge(60 * 60 * 24 * 3);

            response.addCookie(nameCookie);
            response.addCookie(pwdCookie);
        }

    }

    public static boolean isPwdEncryptByMD5(Cookie pwdCookie, User userRequest) {

        if (StringUtil.isEmpty(userRequest.getPassword())) {
            return true;
        }

        if (pwdCookie != null) {
            String cookieVal = pwdCookie.getValue();
            if (userRequest.getPassword().equals(cookieVal)) {
                return true;
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

    public static String transferred(String value) {
        if (value == null){
            return null;
        }
        char content[] = new char[value.length()];
        value.getChars(0, value.length(), content, 0);
        StringBuffer result = new StringBuffer(content.length + 50);
        for (int i = 0; i < content.length; i++) {
            switch (content[i]) {
                case '<':
                    result.append("&lt;");
                    break;
                case '>':
                    result.append("&gt;");
                    break;
                case '&':
                    if (content[i + 1] == 'g' || content[i + 1] == 'l' || content[i + 1] == 'a' || content[i + 1] == 'q') {
                        result.append(content[i]);
                    }else {
                        result.append("&amp;");
                    }
                    break;
                case '"':
                    result.append("&quot;");
                    break;
                default:
                    result.append(content[i]);
            }
        }
        return result.toString();
    }

}
