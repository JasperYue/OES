package common;

import java.util.HashMap;
import java.util.Map;

public class ModelAndView {

    private Map<String, Object> sessionMap = new HashMap<>();
    private Map<String, Object> requestMap = new HashMap<>();
    private Map<String, Object> responseMap = new HashMap<>();

    public void setAttrAtSession(String key, Object value) {
        sessionMap.put(key, value);
    }

    public void setAttrAtRequest(String key, Object value) {
        requestMap.put(key, value);
    }

    public void setAttrAtResponse(String key, Object value) {
        responseMap.put(key, value);
    }

    private String view;
    private boolean isRedirect;

    public ModelAndView() {

    }

    public Map<String, Object> getSessionMap() {
        return sessionMap;
    }

    public Map<String, Object> getRequestMap() {
        return requestMap;
    }

    public Map<String, Object> getResponseMap() {
        return responseMap;
    }

    public String getView() {
        return view;
    }

    public void setView(String view) {
        this.view = view;
    }

    public boolean isRedirect() {
        return isRedirect;
    }

    public void setRedirect(boolean isRedirect) {
        this.isRedirect = isRedirect;
    }

}
