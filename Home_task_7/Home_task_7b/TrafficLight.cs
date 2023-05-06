using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7b
{
    internal class ClassicTrafficLight : TrafficLightBase
    {
        public ClassicTrafficLight(string name, int index, int[] timers) : base(name, new string[] { "червоний", "жовтий", "зелений" }, index, timers) { }

        public override string GetCurrentColor()
        {
            return colors[currentState];
        }
    }
}
