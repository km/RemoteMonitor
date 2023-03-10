using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMonitor.Components
{
    internal class GPU :Component
    {
        private long vramTotal;
        public GPU(string name, double temp, double componentUsage, int vRam)
        {
            componentName = name;
            componentType = "GPU";
            update(temp, componentUsage, vRam);
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
