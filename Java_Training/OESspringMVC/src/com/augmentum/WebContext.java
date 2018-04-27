package com.augmentum;

import java.util.HashMap;
import java.util.Map;


public class WebContext {

    private static ThreadLocal<WebContext> webLocal = new ThreadLocal<>();

    private final Map<String, Object> globalVal = new HashMap<>();

    private static String contextPath;

    public void addKeyVal(String key, Object val) {
        globalVal.put(key, val);
    }

    public Object getVal(String key) {
        return globalVal.get(key);
    }

    public static String getContextPath() {
        return contextPath;
    }

    public void setContextPath(String contextPath) {
        if (WebContext.contextPath == null) {
            WebContext.contextPath = contextPath;
        }
    }

    public static WebContext getContext() {
        WebContext webContext = webLocal.get();
        if (webContext == null) {
            webContext = new WebContext();
            webLocal.set(webContext);
        }
        return webContext;
    }

    public static void clear() {
        WebContext webContext = webLocal.get();
        if (webContext != null) {
            webContext.globalVal.clear();
        }
        webContext = null;
    }

}
