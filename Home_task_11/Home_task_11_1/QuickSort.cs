using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Home_task_11_1
{
    public class QuickSort : ISorter
    {
        public void Sort<T>(List<T> list) where T : IComparable<T>
        {
            Sort(list, -1);
        }

        public void Sort<T>(List<T> list, int pivotIndex = -1) where T : IComparable<T>
        {
            int n = list.Count;

            if (pivotIndex < -1 || pivotIndex >= n) return;

            if (pivotIndex == -1)
                Sort(list, 0, list.Count - 1, n/2);
            else
                Sort(list, 0, list.Count - 1, pivotIndex);
        }

        private void Sort<T>(List<T> list, int low, int high, int pivotIndex) where T : IComparable<T>
        {
            if (low < high)
            {
                int pi = Partition(list, low, high, pivotIndex);

                Sort(list, low, pi - 1, low); 
                Sort(list, pi + 1, high, pi + 1);
                /*if (pi > low)
                {
                    Sort(list, low, pi - 1, low);
                }
                if (pi < high)
                {
                    Sort(list, pi + 1, high, high);
                }*/
            }
        }

        private void Swap<T>(List<T> list, int a, int b) where T : IComparable<T>
        {
            T temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }

        private int Partition<T>(List<T> list, int low, int high, int pivotIndex) where T : IComparable<T>
        {
            Swap(list, pivotIndex, high);
            T pivot = list[high];
            int i = low - 1;  

            for (int j = low; j <= high - 1; j++)
            {
                if (list[j].CompareTo(pivot) < 0)
                {
                    Swap(list, ++i, j);
                }
            }
            Swap(list, i + 1, high);
            return i + 1;
        }
        
        /*public int Partition<T>(List<T> list, int low, int high, int pivotIndex) where T : IComparable<T>
        {
            T pivot = list[pivotIndex];
            int i = low;
            int j = high;

            while (true)
            {
                while (list[i].CompareTo(pivot) < 0) i++;
                while (list[j].CompareTo(pivot) > 0) j--;

                if (i >= j)
                    return j;

                Swap(list, i, j);
            }
        }*/
    }
}
