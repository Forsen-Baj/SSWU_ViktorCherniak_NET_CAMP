using System;
using System.Collections.Generic;

namespace Home_task_6_2
{
    public class Sorter
    {
        public IEnumerable<T> GetSorted<T>(params IEnumerable<T>[] lists)
        {
            List<T> result = new List<T>();

            foreach (IEnumerable<T> list in lists)
            {
                result.AddRange(list);
            }

            result.Sort();

            foreach (T item in result)
            {
                yield return item;
            }
        }
    }
}
