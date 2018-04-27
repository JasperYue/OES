package com.augmentum;


public class Constants {

    /** The status constants in system */
    public static final int STATUS_ZERO = 0;
    public static final int STATUS_ONE = 1;
    public static final String NO_CONTENTS = "";
    public static final String SLASH = "/";

    /** Parameter in request */
    public static final String REMEMBER = "remember";
    public static final String QUERY_STRING = "queryString";
    public static final String GO = "go";

    /** The key set in request scope when there is a tip should notify user. */
    public static final String TIP_MESSAGE = "TIP_MESSAGE";
    public static final String ERROR_MESSAGE = "ERROR_MESSAGE";

    public static final String APP_CONTEXT_USER = "USER";
    public static final String APP_CONTEXT_SESSION = "SESSION";

    /** Request mapping URL */
    public static final String APP_URL_PREFIX = "page";
    public static final String APP_URL_USER_PREFIX = "page/user";
    public static final String APP_URL_QUESTION_PREFIX = "page/question";
    public static final String APP_URL_EXAM_PREFIX = "page/exam";


    public static final String LOGIN_PAGE = "login";
    public static final String QUESTION_LIST_PAGE = "page/main";

    public static final String QUESTION_LIST = "question/toQuestionList";
    public static final String TO_LOGIN = "user/login";

    /** The key set in session scope after user login. */
    public static final String USER = "USER";
    public static final String QUESTION = "QUESTION";
    public static final String EXAM = "EXAM";

    /** The key of user's Cookie */
    public static final String NAMECOOKIE = "NAMECOOKIE";
    public static final String PWDCOOKIE = "PWDCOOKIE";

    /** The config file name in config folder */
    public static final String CONFIG_FILE = "app.properties";
    public static final String STATIC_URL = "STATIC_URL";

    /** Default time */
    public static final String TIME_BEGIN = "2000-01-01";
    public static final String TIME_END = "2050-01-01";

}
