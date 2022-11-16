package components;

import oshi.SystemInfo;

public class Component {
    protected String componentName;
    protected long lastUpdated;
    protected double temperature;
    protected double usage;
    protected SystemInfo si;

    public Component()
    {
        si = new SystemInfo();
    }
    public double getTemperature(){
        return temperature;
    }

    public String getComponentName() {
        return componentName;
    }

    public double getUsage() {
        return usage;
    }

    public long getLastUpdated() {
        return lastUpdated;
    }
}
