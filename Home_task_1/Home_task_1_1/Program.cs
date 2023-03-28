using Home_task_1_1;
//hdflkjfhfdlk
try
{
    var values = Console.ReadLine().Split().Select(s => int.Parse(s)).ToList();
    if (values[0] < 2 || values[1] < 2)
        Console.WriteLine("Minimal size is 2x2");
    else
    {
        SpiralMatrix matrix = new SpiralMatrix(values[0], values[1]);
        matrix.Print();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
