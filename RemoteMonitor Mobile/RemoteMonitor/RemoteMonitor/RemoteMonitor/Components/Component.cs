using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMonitor.Components
{
    internal class Component
    {
        protected string componentName;
        protected string componentType;
        protected long lastUpdated;
        protected double temperature;
        protected double usage;

        public Component(string name, string type, long timestamp, double temp, double componentUsage) 
        {
            componentName = name;
            componentType = type;
            lastUpdated = timestamp;
            temperature = temp;
            usage = componentUsage;
        }
        public void setTemperature(double temp)
        {
            temperature = temp;
        }
        public void setUsage(double componentUsage)
        {
            usage = componentUsage;
        }
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
