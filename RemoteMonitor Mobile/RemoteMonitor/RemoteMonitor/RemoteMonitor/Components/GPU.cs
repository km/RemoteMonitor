using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMonitor.Components
{
    public class GPU : Component
    {
        public long vramTotal;
        public GPU(string name, double temp, double componentUsage, int vRam)
        {
            componentName = name;
            componentType = "GPU";
            update(temp, componentUsage, vRam);
        }
        public GPU() 
        {
            componentName = "No GPU detected";
            temperature = 0;
            usage = 0;
            vramTotal = 0;
        }
        public GPU(JObject json)
        {
            componentName = json["componentName"].ToString();
            componentType = "GPU";
            temperature = json["temperature"].ToObject<double>();
            usage = json["usage"].ToObject<double>();
            vramTotal = json["vramTotal"].ToObject<long>();
            update(json);
        }
        public void update(JObject json)
        {
            temperature = json["temperature"].ToObject<double>();
            usage = json["usage"].ToObject<double>();
            vramTotal = json["vramTotal"].ToObject<long>();
        }
        public void update(double temp, double componentUsage, int vRam)
        {
            temperature = temp;
            usage = componentUsage;
            vramTotal = vRam;
        }
        public long getVramTotal()
        {
            return vramTotal;
        }

    }
}
