using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2_1
{
    public abstract class WaterTower
    {
        protected int capacity;
        protected int currentLevel;
        protected int ID;

        public WaterTower(int ID, int capacity)
        {
            this.ID = ID;
            this.capacity = capacity;
            this.currentLevel = 0;
        }

        public abstract void AddWater(int amount);
        public abstract void RemoveWater(int amount);
        // можливо, потрібно повертати булівське значення?
        public abstract void EmptyTower();
        

        public override string ToString()
        {
            return $"Tower {ID};\nCurrent level: {currentLevel} / {capacity};";
        }
    }
}
