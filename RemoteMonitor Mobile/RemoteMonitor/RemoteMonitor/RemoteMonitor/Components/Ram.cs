using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMonitor.Components
{
    internal class Ram : Component
    {
        private long memoryTotal;
        private long memoryAvailable;

        public Ram(string name, long ramTotal, long availableRam)
        {
            componentName = name;
            componentType = "Ram";
            update(ramTotal, availableRam);
        }
        public void update(long ramTotal, long availableRam)
        {
            memoryTotal = ramTotal; 
            memoryAvailable = availableRam;
            usage = availableRam / ramTotal;
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
