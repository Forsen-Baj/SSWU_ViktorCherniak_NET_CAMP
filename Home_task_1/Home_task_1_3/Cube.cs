using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_1_3
{
    public class Cube
    {
        private int[,,] _data;
        private int _size;

        public Cube(int size)
        {
            _size = size;
            _data = new int[size, size, size];
        }

        public override string ToString()
        {
            string result = "";

            for (int y=0; y<_size; y++)
            {
                string face = "";
                for (int x=0; x<_size; x++)
                    for(int z=0; z<_size; z++)
                        face += _data[x, y, z];

                result += face + '\n';
            }
            return result;
        }

        public void RandomFill()
        {
            Random random = new Random();

            for (int x = 0; x < _size; x++)
                for (int y = 0; y < _size; y++)
                    for (int z = 0; z < _size; z++)
                        _data[x, y, z] = random.Next(2);
        }

        public List<Line> GetLines()
        {//Є повтор дуже подібного коду, який можна оптимізувати.
            List<Line> lines = new List<Line>();

            // Check for Y axis lines
            for (int x = 0; x < _size; x++)
                for(int z=0; z < _size; z++)
                    if (_data[x, 0, z] == 0)
                    {
                        int columnSum = 0;
                        for (int y = 0; y < _size; y++)
                            columnSum += _data[x, y, z];
                        if (columnSum == 0)
                            lines.Add(new Line(x,0,z, x,_size-1,z));
                    }

            // Check for X axis lines
            for (int y = 0; y < _size; y++)
                for (int z = 0; z < _size; z++)
                    if (_data[0, y, z] == 0)
                    {
                        int columnSum = 0;
                        for (int x = 0; x < _size; x++)
                            columnSum += _data[x, y, z];
                        if (columnSum == 0)
                            lines.Add(new Line(0, y, z, _size-1, y, z));
                    }

            // Check for Z axis lines
            for (int x = 0; x < _size; x++)
                for (int y = 0; y < _size; y++)
                    if (_data[x, y, 0] == 0)
                    {
                        int columnSum = 0;
                        for (int z = 0; z < _size; z++)
                            columnSum += _data[x, y, z];
                        if (columnSum == 0)
                            lines.Add(new Line(x, y, 0, x, y, _size -1));
                    }

            // Check for diagonal lines
            for (int y = 0; y < _size; y++) {
                if (_data[0, y, 0] == 0)
                {
                    int lineSum = 0;
                    for (int i = 0; i < _size; i++)
                        lineSum += _data[i, y, i];
                    if (lineSum == 0)
                        lines.Add(new Line(0, y, 0, _size-1, y, _size - 1));
                }

                if (_data[_size-1, y, 0] == 0)
                {
                    int lineSum = 0;
                    for (int i = 0; i < _size; i++)
                        lineSum += _data[_size - i - 1, y, _size - i - 1];
                    if (lineSum == 0)
                        lines.Add(new Line(_size - 1, y, 0, 0, y, _size - 1));
                }
            }

            return lines;
        }

    }
}
