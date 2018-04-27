package com.augmentum.util;

import com.augmentum.Constants;
import com.augmentum.WebContext;

public final class StringUtil {

    /**
     * Judge the string whether it is empty.
     * @param data
     * @return
     */
    public static boolean isEmpty(String data) {
        if (data == null || Constants.NO_CONTENTS.equals(data.trim())) {
            return true;
        }
        return false;
    }

    public static boolean isEquals(String prev, String next) {
        if (prev.equals(next)) {
            return true;
        }
        return false;
    }

    public static String getFullPath(String path) {
        if (path == null) {
            path = Constants.NO_CONTENTS;
        }
        String prefix = Constants.APP_URL_PREFIX;
        if (!StringUtil.isEmpty(prefix)) {
            prefix += Constants.SLASH;
        }
        return WebContext.getContextPath() + Constants.SLASH + prefix + path;
    }

}
