package com.augmentum.util;

import java.text.MessageFormat;

import com.augmentum.listener.LoadResource;

public final class MessageUtil {

    /** Database related error */
    public static final String DB_FILL_PARAMETERS_ERROR = "100001";

    /** Reflection related error */
    public static final String REFLECT_DATA2OBJ_ERROR = "200001";

    /** Data validate error */
    public static final String DATA_VALIDATE_ERROR = "300001";
    public static final String DATA_NOSELECTED_ERROR = "300002";
    public static final String DATA_PART_DELETE = "300003";
    public static final String REQUIRED_FIELD_ERROR = "300004";
    public static final String NUMBERIC_FIELD_ERROR = "300005";
    public static final String SAVE_AS_DRAFT = "300006";
    public static final String TIME_FORMAT_ERROR = "300007";
    public static final String DATA_TOO_LONG = "300008";
    public static final String ITEM_REPEAT = "300009";

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

    public static final String ADD_QUESTION_SUC = "Add question successfully!";
    public static final String EDIT_QUESTION_SUC = "Edit question successfully!";
    public static final String EDIT_QUESTION_DATA_ERROR = "Invalid Data";
    public static final String DELETE_QUESTION_SUC = "Delete question successfully!";

    public static final String ADD_EXAM_SUC = "Add exam successfully!";

    public static String buildMessage(String errCode, Object...errMsg) {
        String msg = LoadResource.getProperty(errCode);
        return MessageFormat.format(msg, errMsg);
    }

}
