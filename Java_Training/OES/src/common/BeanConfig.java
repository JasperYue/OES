package common;

import java.util.ArrayList;
import java.util.List;

public class BeanConfig {
    private String id;
    private String classFullName;
    private String scope;

    private List<BeanProperty> propertiesList = new ArrayList<>();

    public BeanConfig(String id, String classFullName, String scope) {
        this.id = id;
        this.classFullName = classFullName;
        this.scope = scope;
    }

    public void setProperty(BeanProperty beanProperty) {
        propertiesList.add(beanProperty);
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getClassFullName() {
        return classFullName;
    }

    public void setClassFullName(String classFullName) {
        this.classFullName = classFullName;
    }

    public String getScope() {
        return scope;
    }

    public void setScope(String scope) {
        this.scope = scope;
    }

    public List<BeanProperty> getPropertiesList() {
        return propertiesList;
    }

}
