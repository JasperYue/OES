package common;

import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

public class ActionConfig {

    private String name;
    private String className;
    private String methodName;
    private String httpMethod;

    private Map<String, ResultConfig> results = new ConcurrentHashMap<>();

    public void addResult(String key, ResultConfig resultConfig) {
        results.put(key, resultConfig);
    }

    public ResultConfig getResult(String resultKey) {
        return results.get(resultKey);
    }

    public Map<String, ResultConfig> getResults() {
        return results;
    }

    public void setResults(Map<String, ResultConfig> results) {
        if (results == null) {
            results = new ConcurrentHashMap<String, ResultConfig>();
        }
        this.results = results;
    }

    public ActionConfig(String name, String className, String methodName, String httpMethod) {
        super();
        this.name = name;
        this.className = className;
        this.methodName = methodName;
        this.httpMethod = httpMethod;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getClassName() {
        return className;
    }

    public void setClassName(String className) {
        this.className = className;
    }

    public String getMethodName() {
        return methodName;
    }

    public void setMethodName(String methodName) {
        this.methodName = methodName;
    }

    public String getHttpMethod() {
        return httpMethod;
    }

    public void setHttpMethod(String httpMethod) {
        this.httpMethod = httpMethod;
    }

}
