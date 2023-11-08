using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RemoteMonitor.Components
{
    public class Ram : Component
    {
        public long memoryTotal;
        public long memoryAvailable;

        public Ram(string name, long ramTotal, long availableRam)
        {
            componentType = "Ram";
            componentName = "";
            memoryTotal = ramTotal;
            memoryAvailable = availableRam;
            update(ramTotal, availableRam);
        }
        public Ram(JObject json)
        {
            componentType = "Ram";
            componentName = "";

            memoryAvailable = json["memoryAvailable"].ToObject<long>();
            memoryTotal = json["memoryTotal"].ToObject<long>();
            usage = 0;
            update(json);
        }
        public void update(JObject json)
        {
            memoryAvailable = json["memoryAvailable"].ToObject<long>();
            memoryTotal = json["memoryTotal"].ToObject<long>();

            usage = (double)(memoryTotal - memoryAvailable) / memoryTotal;
            Debug.WriteLine("Ram usage: " + usage);
        }
        public void update(long ramTotal, long availableRam)
        {
            memoryTotal = ramTotal; 
            memoryAvailable = availableRam;

            usage = (double)(memoryTotal - memoryAvailable) / memoryTotal;



        }
        public long getMemoryAvailable()
        {
            return memoryAvailable;
        }
        public long getMemoryTotal()
        {
            return memoryTotal;
        }
    }
}
