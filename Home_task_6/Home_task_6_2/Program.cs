using Home_task_6_2;

Sorter sorter = new Sorter();
List<int> list1 = new List<int> { 3, 1, 4, -1, 4, 0 };
List<int> list2 = new List<int> { 2, 6 };
int[] array1 = { 5, 9, 7, 0, -13 };

foreach (int item in sorter.GetSorted(list1, list2, array1))
{
    Console.Write(item + " ");
}