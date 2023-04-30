using Home_task_6_1;


//----------------------------------
Matrix matrix = new Matrix(4);
Console.WriteLine(matrix);

foreach (int x in matrix)
{
    Console.Write("{0} ", x);
}

Console.WriteLine();
//----------------------------------



//----------------------------------
int[,] test = new int[3, 4] {
    { 1, 2, 3, 4 },
    { 5, 6, 7, 8 },
    { 9, 10, 11, 12}
};

Matrix matrix1 = new Matrix(test);
Console.WriteLine(matrix1);

foreach (int x in matrix1)
{
    Console.Write("{0} ", x);
}

Console.WriteLine();
//----------------------------------


//----------------------------------
List<List<int>> test2 = new List<List<int>> {
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5, 6 },
    new List<int> { 7, 8, 9 },
    new List<int> { 10, 11, 12 },
    new List<int> { 13, 14, 15 }
};

Matrix matrix2 = new Matrix(test2);
Console.WriteLine(matrix2);

foreach (int x in matrix2)
{
    Console.Write("{0} ", x);
}

Console.WriteLine();
//----------------------------------