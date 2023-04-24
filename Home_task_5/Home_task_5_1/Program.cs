using Home_task_5_1;
//90	10	0	95	88	85	75	91,6 
List<Point> points = new List<Point>();

points.Add(new Point(1, 1));
points.Add(new Point(1, 4));
points.Add(new Point(4, 5));
points.Add(new Point(2, 5));
points.Add(new Point(5, 1));
points.Add(new Point(4, 0));
points.Add(new Point(2, 0));
points.Add(new Point(5, 4));
points.Add(new Point(3, 2));

var garden = new Garden(points);
garden.CalculatePerimeter();
Console.WriteLine(garden.perimeter);

var randomGarden = new Garden(3);
randomGarden.CalculatePerimeter();

Console.WriteLine(String.Join("\n", randomGarden.trees));

Console.WriteLine(randomGarden.perimeter);
Console.WriteLine(randomGarden>garden);
