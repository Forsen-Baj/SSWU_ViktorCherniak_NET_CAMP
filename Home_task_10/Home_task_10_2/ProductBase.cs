using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10_2
{
    public abstract class ProductBase : IProduct
    {
        public decimal Weight { get; }
        public decimal Size { get; }
        public decimal Price { get; }

        protected ProductBase(decimal weight, decimal size, decimal price)
        {
            Weight = weight;
            Size = size;
            Price = price;
        }

        public abstract void Accept(IShippingCostVisitor visitor);
    }
}
