using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7b
{
    internal class Crossroad : IntersectionBase
    {
        
        public Crossroad(string name) : base("Crossroad | " + name) {}

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
