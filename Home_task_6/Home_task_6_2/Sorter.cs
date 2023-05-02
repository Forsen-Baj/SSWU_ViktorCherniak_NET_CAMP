using System;
using System.Collections.Generic;

namespace Home_task_6_2
{
    public class Sorter
    {// У цьому випадку краще цей метод зробити статичним. Але мені подобається його узагальнена сигнатура. Покажіть для всіх на занятті.
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
