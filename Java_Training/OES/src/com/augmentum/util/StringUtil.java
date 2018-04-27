package com.augmentum.util;

public final class StringUtil {

    /**
     * Judge the string whether it is empty.
     * @param data
     * @return
     */
    public static boolean isEmpty(String data) {
        if (data == null || "".equals(data.trim())) {
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

}
