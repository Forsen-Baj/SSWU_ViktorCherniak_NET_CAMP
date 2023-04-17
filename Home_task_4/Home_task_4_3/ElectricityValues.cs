using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_4_3
{
    internal class ElectricityValues
    {
        private Dictionary<DateTime, int> values;

        public ElectricityValues()
        {
            values = new Dictionary<DateTime, int>();
        }

        public void AddValue(DateTime date, int value)
        {
            values[date] = value;
        }

        public (DateTime minDate, int minValue) GetMinValues()
        {
            return (values.Keys.Min(), values.Values.Min());
        }

        public (DateTime maxDate, int maxValue) GetMaxValues()
        {
            return (values.Keys.Max(), values.Values.Max());
        }
    }
}
