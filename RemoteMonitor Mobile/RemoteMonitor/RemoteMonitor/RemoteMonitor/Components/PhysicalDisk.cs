using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMonitor.Components
{
    internal class PhysicalDisk : Component 
    {
        private long capacity;
        private long availableCapacity;

        public PhysicalDisk(string name, double temp, long diskCapacity, long availableDiskCapacity)
        {
            componentName = name;
            componentType = "Disk";
            update(temp, diskCapacity, availableDiskCapacity);
        }
        public void update(double temp, long diskCapacity, long availableDiskCapacity)
        {
            temperature = temp;
            capacity= diskCapacity;
            availableCapacity= availableDiskCapacity;
            usage = availableCapacity / capacity;
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
