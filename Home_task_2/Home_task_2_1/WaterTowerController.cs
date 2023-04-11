using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2_1
{
    public abstract class WaterTowerController
    {
        protected WaterTower waterTower;
        protected Pump pump;
        protected int ID;

        public WaterTowerController(int ID, WaterTower waterTower, Pump pump)
        {
            this.ID = ID;
            this.waterTower = waterTower;
            this.pump = pump;
        }
// Контролер не використовує воду. Він тільки регулює. Використовує воду користувач.
        public abstract void UseWater(int amount);

        public override string ToString()
        {
            return $"Controller {ID}\n[{waterTower}];\n[{pump}]\n";
        }
    }
}
