using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMonitor.Components
{
    public class Component
    {
        public string componentName;
        public string componentType;
        public long lastUpdated;
        public double temperature;
        public double usage;

        public double getTemperature()
        {
            return temperature;
        }

        public String getComponentName()
        {
            return componentName;
        }

        public double getUsage()
        {
            return usage;
        }

        public long getLastUpdated()
        {
            return lastUpdated;
        }
    }
}
