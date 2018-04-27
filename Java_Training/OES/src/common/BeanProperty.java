package common;

public class BeanProperty {

    private String name;
    private String ref;

    public BeanProperty(String name, String ref) {
        super();
        this.name = name;
        this.ref = ref;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getRef() {
        return ref;
    }

    public void setRef(String ref) {
        this.ref = ref;
    }

}
