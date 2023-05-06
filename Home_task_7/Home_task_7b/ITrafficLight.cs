using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7b
{
    internal interface ITrafficLight
    {
        string Name { get; }
        string GetCurrentColor();
        void Tick(int time);
    }
}
