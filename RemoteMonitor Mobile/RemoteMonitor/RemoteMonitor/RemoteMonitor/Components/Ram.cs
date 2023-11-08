using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            memoryTotal = ramTotal;
            memoryAvailable = availableRam;
            update(ramTotal, availableRam);
        }
        public Ram(JObject json)
        {
            componentType = "Ram";
            memoryAvailable = json["memoryAvailable"].ToObject<long>();
            memoryTotal = json["memoryTotal"].ToObject<long>();
            update(json);
        }
        public void update(JObject json)
        {
            memoryAvailable = json["memoryAvailable"].ToObject<long>();
            memoryTotal = json["memoryTotal"].ToObject<long>();
            
            usage = (double) memoryAvailable / memoryTotal;
        }
        public void update(long ramTotal, long availableRam)
        {
            memoryTotal = ramTotal; 
            memoryAvailable = availableRam;

            usage = (double)memoryAvailable / memoryTotal;
           
          
           
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
