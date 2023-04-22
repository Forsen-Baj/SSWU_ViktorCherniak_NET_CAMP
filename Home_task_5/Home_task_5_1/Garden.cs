using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_5_1
{
    class Garden : IComparable<Garden>
    {// периметр краще робити результатом методу, а не полем.
        public double perimeter;
        //порушення інкапсуляції
        public List<Point> trees;

        public Garden()
        {
            this.trees = new List<Point>();
            this.perimeter = 0;
        }

        public Garden(List<Point> trees)
        {// Слід робити глибоку копію
            this.trees = new List<Point>(trees); 
            this.perimeter = 0;
        }

        public Garden(int n)
        {
            this.trees = new List<Point>();
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                double x = Math.Round(rnd.NextDouble() * 10, 2);
                double y = Math.Round(rnd.NextDouble() * 10, 2);
                this.trees.Add(new Point(x, y));
            }
            this.perimeter = 0;
        }

        public double CalculatePerimeter()
        {
            this.perimeter = BuildPerimeter(this.trees);
            return this.perimeter;
        }

        public static bool operator> (Garden a, Garden b)
        {
            return a.perimeter > b.perimeter;
        }

        public static bool operator <(Garden a, Garden b)
        {
            return a.perimeter < b.perimeter;
        }

        public static bool operator ==(Garden a, Garden b)
        {
            return a.perimeter == b.perimeter;
        }

        public static bool operator !=(Garden a, Garden b)
        {
            return a.perimeter == b.perimeter;
        }

        public static bool operator <=(Garden a, Garden b)
        {
            return a.perimeter <= b.perimeter;
        }

        public static bool operator >=(Garden a, Garden b)
        {
            return a.perimeter <= b.perimeter;
        }

        public int CompareTo(Garden other)
        {
            return this.perimeter.CompareTo(other.perimeter);
        }

        private double BuildPerimeter(List<Point> points)
        {
            // Monotone Chain algorithm
            if (points.Count < 3)
                return 0;

            points.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

            List<Point> upperHull = new List<Point>();
            List<Point> lowerHull = new List<Point>();

            // Build upper hull
            foreach (Point point in points)
            {
                while (upperHull.Count >= 2)
                {
                    int n = upperHull.Count;
                    Point prev = upperHull[n - 2];
                    Point curr = upperHull[n - 1];
                    if ((curr.X - prev.X) * (point.Y - curr.Y) >= (curr.Y - prev.Y) * (point.X - curr.X))
                        upperHull.RemoveAt(n - 1);
                    else
                        break;
                }
                upperHull.Add(point);
            }

            // Build lower hull
            for (int i = points.Count - 1; i >= 0; i--)
            {
                Point point = points[i];
                while (lowerHull.Count >= 2)
                {
                    int n = lowerHull.Count;
                    Point prev = lowerHull[n - 2];
                    Point curr = lowerHull[n - 1];
                    if ((curr.X - prev.X) * (point.Y - curr.Y) >= (curr.Y - prev.Y) * (point.X - curr.X))
                        lowerHull.RemoveAt(n - 1);
                    else
                        break;
                }
                lowerHull.Add(point);
            }

            List<Point> hull = new List<Point>(upperHull);
            hull.RemoveAt(hull.Count - 1);
            hull.AddRange(lowerHull);

            // Calculate perimeter
            double perimeter = 0;
            for (int i = 0; i < hull.Count; i++)
            {
                Point curr = hull[i];
                Point next = hull[(i + 1) % hull.Count];
                perimeter += Math.Sqrt(Math.Pow(next.X - curr.X, 2) + Math.Pow(next.Y - curr.Y, 2));
            }

            return perimeter;
        }
    }
}
