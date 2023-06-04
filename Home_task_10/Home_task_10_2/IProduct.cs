using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10_2
{
    public interface IProduct
    {
        decimal Weight { get; }
        decimal Size { get; }
        decimal Price { get; }
        void Accept(IShippingCostVisitor visitor);
    }
}
