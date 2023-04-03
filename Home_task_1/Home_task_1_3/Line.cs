using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_1_3
{
    public class Line
    {
        public (int X, int Y, int Z) startPoint;
        public (int X, int Y, int Z) endPoint;

        public Line()
        {
            startPoint = new (0, 0, 0);
            endPoint = new(0, 0, 0);
        }

        public Line(int startX, int startY, int startZ, int endX, int endY, int endZ)
        {
            startPoint = new(startX, startY, startZ);
            endPoint = new(endX, endY, endZ);
        }

        public override string ToString()
        {
            return $"{startPoint}, {endPoint};\n";
        }
    }
}
