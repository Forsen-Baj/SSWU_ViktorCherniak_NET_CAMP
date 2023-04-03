namespace Home_task_1_3;

class Program
{
    static void Main()
    {
        Cube cube = new Cube(3);
        cube.RandomFill();
        var lines = cube.GetLines();
        Console.WriteLine(String.Join("\n", lines));
    }
}


