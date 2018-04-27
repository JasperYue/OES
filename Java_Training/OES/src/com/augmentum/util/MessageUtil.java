package com.augmentum.util;

import java.text.MessageFormat;

import com.augmentum.listener.LoadResource;

public final class MessageUtil {

    /** Database related error */
    public static final String DB_ACCESS_ERROR = "100001";
    public static final String DB_LOAD_DRIVER_ERROR = "100002";
    public static final String DB_GET_CONNECT_ERROR = "100003";
    public static final String DB_FILL_PARAMETERS_ERROR = "100004";
    public static final String DB_UPDATE_OBJECT_ERROR = "100005";
    public static final String DB_QUERY_OBJECT_ERROR = "100006";
    public static final String DB_QUERY_OBJECTLIST_ERROR = "100007";
    public static final String DB_QUERY_SINGLEVALUE_ERROR = "100008";
    public static final String DB_RETURN_GENERATEKEY_ERROR = "100009";
    public static final String DB_BATCH_ERROR = "100010";
    public static final String DB_CLOSE_ERROR = "100011";


    /** Reflection related error */
    public static final String REFLECT_DATA2OBJ_ERROR = "200001";
    public static final String REFLECT_REQUEST2OBJ_ERROR = "200002";

    /** Data validate error */
    public static final String DATA_VALIDATE_ERROR = "300001";
    public static final String DATA_NOSELECTED_ERROR = "300002";
    public static final String DATA_PART_DELETE = "300003";
    public static final String REQUIRED_FIELD_ERROR = "300004";
    public static final String NUMBERIC_FIELD_ERROR = "300005";
    public static final String SAVE_AS_DRAFT = "300006";
    public static final String TIME_FORMAT_ERROR = "300007";

    /** Entity related error */
    public static final String ENTITY_NOT_FOUND = "400001";
    public static final String ENTITY_CREATE_FAILED = "400002";
    public static final String ENTITY_UPDATE_FAILED = "400003";
    public static final String ENTITY_DELETE_FAILED = "400004";
    public static final String ENTITY_DELETE_ALREADY = "400005";

    /** Other error */
    public static final String INTERNAL_SERVER_ERROR = "500";
    public static final String LOAD_PROPERTIES_FILE_FAIL = "500001";
    public static final String CLOSE_STREAM_FAIL = "500002";

    /** Entity */
    public static final String ENTITY_USER = "User";
    public static final String ENTITY_QUESTION = "Question";
    public static final String ENTITY_EXAM = "Exam";

    /** The attribute in user */
    public static final String ENTITY_USER_NAME = "name";
    public static final String ENTITY_USER_PASSWORD = "password";

    /** The attribute in question */
    public static final String ENTITY_QUESTION_NUM = "num";
    public static final String ENTITY_QUESTION_TITLE = "title";
    public static final String ENTITY_QUESTION_ITEMA = "itemA";
    public static final String ENTITY_QUESTION_ITEMB = "itemB";
    public static final String ENTITY_QUESTION_ITEMC = "itemC";
    public static final String ENTITY_QUESTION_ITEMD = "itemD";
    public static final String ENTITY_QUESTION_ANSWER = "answer";

    /** The attribute in exam */
    public static final String ENTITY_EXAM_NAME = "name";
    public static final String ENTITY_EXAM_EFFECTIVETIME = "effectiveTime";
    public static final String ENTITY_EXAM_DURATION = "duration";
    public static final String ENTITY_EXAM_SINGLESCORE = "singleScore";
    public static final String ENTITY_EXAM_NEEDQUANTITY = "needQuantity";
    public static final String ENTITY_EXAM_TOTALSCORE = "totalScore";
    public static final String ENTITY_EXAM_PASSCRITERIA = "passCriteria";

    /** The attribute name of JDBC resource */
    public static final String JDBC_RESULTSET = "ResultSet";
    public static final String JDBC_PREPAREDSTATEMENT = "PreparedStatement";
    public static final String JDBC_CONNECTION = "Connection";

    public static String buildMessage(String errCode, Object...errMsg) {
        String msg = LoadResource.getProperty(errCode);
        return MessageFormat.format(msg, errMsg);
    }

}
