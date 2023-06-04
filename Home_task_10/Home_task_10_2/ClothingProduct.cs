using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10_2
{
    public class ClothingProduct : ProductBase
    {
        public ClothingProduct(decimal weight, decimal size, decimal price) : base(weight, size, price) { }

        public override void Accept(IShippingCostVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
