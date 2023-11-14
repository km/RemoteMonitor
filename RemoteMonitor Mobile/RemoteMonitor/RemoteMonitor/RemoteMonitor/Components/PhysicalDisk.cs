using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMonitor.Components
{
    public class PhysicalDisk : Component 
    {
        public long capacity;
        public long availableCapacity;

        public PhysicalDisk() 
        {
            componentName = "No Disk detected";
            componentType = "Disk";
            temperature = 0;
            capacity = 0;
            availableCapacity = 0;
        }
        public PhysicalDisk(string name, double temp, long diskCapacity, long availableDiskCapacity)
        {
            componentName = name;
            componentType = "Disk";
            temperature = temp;
            capacity = diskCapacity;
            availableCapacity = availableDiskCapacity;
            update(temp, diskCapacity, availableDiskCapacity);
        }
        public void update(double temp, long diskCapacity, long availableDiskCapacity)
        {
            temperature = temp;
            capacity= diskCapacity;
            availableCapacity= availableDiskCapacity;
            if(capacity != 0)
                usage = availableCapacity / capacity;
        }
        public PhysicalDisk(JObject json)
        {
            componentName = json["componentName"].ToString();
            componentType = "Disk";
            temperature = json["temperature"].ToObject<double>();
            capacity = json["capacity"].ToObject<long>();
            availableCapacity = json["availableCapacity"].ToObject<long>();
            usage = json["usage"].ToObject<double>();
            update(json);
        }
        public void update(JObject json)
        {
            temperature = json["temperature"].ToObject<double>();
            capacity = json["capacity"].ToObject<long>();
            availableCapacity = json["availableCapacity"].ToObject<long>();
            usage = json["usage"].ToObject<double>();
        }
        public long getAvailableCapacity()
        {
            return availableCapacity;
        }

        public long getCapacity()
        {
            return capacity;
        }
    }
}
