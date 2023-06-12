using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_11_1
{
    public interface ISorter
    {
        void Sort<T>(List<T> collection) where T : IComparable<T>;
    }
}
