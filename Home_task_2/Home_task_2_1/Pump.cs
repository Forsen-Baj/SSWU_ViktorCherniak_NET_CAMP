using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2_1
{
    public abstract class Pump
    {
        protected int power;
        protected int ID;
        protected bool state;

        public Pump(int ID, int power)
        {
            this.power = power;
            this.ID = ID;
            this.state = false;
        }

        public Pump(Pump pump)
        {
            this.power = pump.power;
            this.ID = pump.ID;
            this.state = false;
        }

        public abstract void PumpWater(WaterTower tower);

        public override string ToString()
        {
            return $"Pump {ID};\nPower: {power}, state: {state};";
        }
    }
}
