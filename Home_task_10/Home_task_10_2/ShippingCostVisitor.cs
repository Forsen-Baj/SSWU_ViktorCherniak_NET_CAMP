using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10_2
{
    public class ShippingCostVisitor : IShippingCostVisitor
    {
        public decimal ShippingCost { get; private set; }

        public void Visit(FoodProduct product)
        {
            ShippingCost = product.Weight * 0.2m + product.Size * 0.1m;
        }

        public void Visit(ElectronicProduct product)
        {
            ShippingCost = product.Weight * 0.15m + product.Size * 0.2m;

            if (product.Size > 10)
                ShippingCost += product.Price * 0.05m;
        }

        public void Visit(ClothingProduct product)
        {
            ShippingCost = product.Weight * 0.1m + product.Size * 0.1m;
        }
    }
}
