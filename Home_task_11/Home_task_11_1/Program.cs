using Home_task_11_1;
using System;
using System.Diagnostics;

var sorter = new QuickSort();

int N = 20; Random random = new Random();

decimal ticks = 0;

for (int i = 0; i < 1; i++)
{
    List<int> numbers = Enumerable.Range(0, N)
                                                .Select(_ => random.Next(1000))
                                                .ToList();


    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    sorter.Sort(numbers, 0);

    stopwatch.Stop();
    ticks += stopwatch.ElapsedMilliseconds;
    Console.WriteLine(String.Join(" ", numbers));
}