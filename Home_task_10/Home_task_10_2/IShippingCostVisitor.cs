using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10_2
{
    public interface IShippingCostVisitor
    {
        void Visit(FoodProduct product);
        void Visit(ElectronicProduct product);
        void Visit(ClothingProduct product);
    }
}
