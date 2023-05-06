using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7b
{
    internal class TrafficLightController
    {
        private List<TrafficLightBase> trafficLights;

        public TrafficLightController(IEnumerable<TrafficLightBase> trafficLights)
        {
            this.trafficLights = new List<TrafficLightBase>();

            foreach (var trafficLight in trafficLights)
                this.trafficLights.Add(trafficLight);
        }

        public void ImitateConsole(int interval, int maxTime = -1)
        {
            int currentTime = 0;

            while (true)
            {
                if (currentTime == maxTime)
                    break;

                Console.WriteLine($"\nt={currentTime} с.");

                foreach (var trafficLight in trafficLights)
                {
                    Console.WriteLine($"{trafficLight.Name}\t\t\t{trafficLight.GetCurrentColor()}");
                    trafficLight.Tick(interval);
                }

                currentTime++;

                Thread.Sleep(interval * 1000);
            }
        }
    }
}
