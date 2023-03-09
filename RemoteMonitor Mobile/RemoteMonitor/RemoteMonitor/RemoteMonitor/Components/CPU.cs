using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static Xamarin.Essentials.Permissions;

namespace RemoteMonitor.Components
{
    internal class CPU : Component
    { 
        private int cores;
        private long speed;
        private long[] currentSpeed;
        private int[] fanSpeed;
        public CPU(string name, string type, double temp, double componentUsage, int coreAmount, long maxSpeed, long[] currentSpeeds, int[] fanSpeeds)
        {
            componentName = name;
            componentType = type;
            update(temp, componentUsage, coreAmount, maxSpeed, currentSpeeds, fanSpeeds);
        }
        public void update(double temp, double componentUsage, int coreAmount, long maxSpeed, long[] currentSpeeds, int[] fanSpeeds)
        {
            temperature= temp;
            usage = componentUsage;
            cores = coreAmount;
            speed = maxSpeed;
            currentSpeed= currentSpeeds;
            fanSpeed = fanSpeeds;

        }
        public int[] getFanSpeeds()
        {
            return fanSpeed;
        }
        public long getSpeed()
        {
            return speed;
        }
        public long[] getCurrentSpeed()
        {
            return currentSpeed;
        }
        public int getCores()
        {
            return cores;
        }
    }
}
