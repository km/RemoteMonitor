using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static Xamarin.Essentials.Permissions;

namespace RemoteMonitor.Components
{
    public class CPU : Component
    { 
        public int cores;
        public long speed;
        public long[] currentSpeed;
        public int[] fanSpeed;
        public CPU(string name, double temp, double componentUsage, int coreAmount, long maxSpeed, long[] currentSpeeds, int[] fanSpeeds)
        {
            componentName = name;
            componentType = "CPU";
            update(temp, componentUsage, coreAmount, maxSpeed, currentSpeeds, fanSpeeds);
        }
        public CPU(JObject json) 
        {
            componentName = json["componentName"].ToString();
            componentType = "CPU";

            update(json);
         
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
        public void update(JObject json) 
        {
            temperature = ((double)json["temperature"]);
            usage = ((double)json["usage"]);
            cores = json["cores"].ToObject<int>();
            speed = json["speed"].ToObject<long>();
            currentSpeed = json["currentSpeed"].ToObject<long[]>();
            fanSpeed = json["fanSpeeds"].ToObject<int[]>();
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
