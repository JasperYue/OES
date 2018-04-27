package common;

import java.util.ArrayList;
import java.util.List;

public class ResultConfig {

    private String name;
    private String type;
    private String view;
    private boolean redirect;

    private List<ViewParameterConfig> viewParameterConfigs = new ArrayList<>();

    public void addViewParameterConfig(ViewParameterConfig viewParameterConfig) {
        this.viewParameterConfigs.add(viewParameterConfig);
    }

    public List<ViewParameterConfig> getViewParameterConfigs() {
        return viewParameterConfigs;
    }

    public void setViewParameterConfigs(List<ViewParameterConfig> viewParameterConfigs) {
        if (viewParameterConfigs == null) {
            this.viewParameterConfigs = new ArrayList<ViewParameterConfig>();
        }
        this.viewParameterConfigs = viewParameterConfigs;
    }

    public ResultConfig(String name, String type) {
        super();
        this.name = name;
        this.type = type;
    }

    public ResultConfig(String name, String view, boolean redirect) {
        super();
        this.name = name;
        this.view = view;
        this.redirect = redirect;
    }

    public ResultConfig(String name, String type, String view, boolean redirect) {
        this.name = name;
        this.type = type;
        this.view = view;
        this.redirect = redirect;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getView() {
        return view;
    }

    public void setView(String view) {
        this.view = view;
    }

    public boolean isRedirect() {
        return redirect;
    }

    public void setRedirect(boolean redirect) {
        this.redirect = redirect;
    }

}
