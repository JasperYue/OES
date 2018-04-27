package com.augmentum;


public class Constants {

    /** The status constants in system */
    public static final int STATUS_ZERO = 0;
    public static final int STATUS_ONE = 1;

    /** Parameter in request*/
    public static final String REMEMBER = "remember";
    public static final String METHOD = "method";

    /** The key set in request scope when there is a tip should notify user. */
    public static final String TIP_MESSAGE = "TIP_MESSAGE";
    public static final String ERROR_MESSAGE = "ERROR_MESSAGE";

    public static final String FUZZYCRITERION = "FUZZYCRITERION";

    /** The key set in session scope after user login. */
    public static final String USER = "USER";
    public static final String QUESTION = "QUESTION";
    public static final String EXAM = "EXAM";

    /** The key of user's Cookie */
    public static final String NAMECOOKIE = "NAMECOOKIE";
    public static final String PWDCOOKIE = "PWDCOOKIE";

    /** The location of login page. */
    public static final String LOGIN_PAGE = "/WEB-INF/jsp/login.jsp";
    public static final String QUESTION_LIST_PAGE = "/WEB-INF/jsp/question_list.jsp";
    public static final String QUESTION_EDIT_PAGE = "/WEB-INF/jsp/question_edit.jsp";

    /** JDBC related informations */
    public static final String JDBC_CLASS_NAME = "CLASS_NAME";
    public static final String JDBC_URL = "URL";
    public static final String JDBC_USER = "USER";
    public static final String JDBC_PASSWORD = "PASSWORD";

    /** The config file name in config folder */
    public static final String CONFIG_FILE = "app.properties";

}
