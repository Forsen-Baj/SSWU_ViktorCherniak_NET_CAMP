using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7b
{
    internal abstract class TrafficLightBase : ITrafficLight
    {
        public string Name { get; protected set; }
        protected string[] colors;
        protected int[] timeForEachState;
        protected int currentState;
        protected int timer = 0;

        public TrafficLightBase(string name, string[] colors, int index, int[] timers)
        {
            Name = name;
            this.colors = colors;
            currentState = index;

            if (timers.Length != colors.Length)
                throw new ArgumentException();

            timeForEachState = timers;
        }

        public void Tick(int time)
        {
            timer += time;
            if (timer >= timeForEachState[currentState])
            {
                Switch();
                timer = 0;
            }
        }
        public abstract string GetCurrentColor();

        private void Switch()
        {
            currentState = (currentState + 1) % colors.Length;
        }
    }
}
