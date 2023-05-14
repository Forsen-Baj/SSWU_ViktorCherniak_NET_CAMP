using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7b
{
    internal abstract class IntersectionBase
    {
        public string Name { get; protected set; }
        public List<TrafficLightBase> trafficLights;

        public IntersectionBase(string name)
        {
            Name = name;
            trafficLights = new List<TrafficLightBase>();
        }

        public void AddTrafficLight(TrafficLightBase trafficLight)
        {
            trafficLights.Add(trafficLight);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
