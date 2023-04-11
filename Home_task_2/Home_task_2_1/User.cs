using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2_1
{
    public abstract class User
    {// чому ідентифікатор поля з великої?
        protected int ID;
        protected int demandedWater;
        protected int receivedWater;

        public User(int ID)
        {
            this.ID = ID;
            this.demandedWater = 0;
            this.receivedWater = 0;
        }
       
        public abstract void UseWater(WaterTowerController controller, int amount)? Як буде контролюватися, чи зміг користувач здобути воду. Про це слід повідомляти симулятора.

        public override string ToString()
        {
            return $"User: {ID};\nReceived: {receivedWater}L;\nRequested: {demandedWater};";
        }
    }
}
