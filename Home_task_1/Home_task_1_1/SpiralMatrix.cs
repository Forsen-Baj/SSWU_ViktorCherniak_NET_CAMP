using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_1_1
{
    public class SpiralMatrix
    {
        int _width;
        int _height;
        int[,] _matrix;

        public SpiralMatrix(int height = 4, int width = 4)
        {
            if (height < 0 || width < 0)
            {
                _width = 0;
                _height = 0;
                _matrix = new int[0, 0];
            }
            else
            {
                _width = width;
                _height = height;
                _matrix = new int[width, height];
            }
        }

        
        bool IsCompleted(int counter)
        {
            return counter > _width * _height;
        }
        void _generateMatrix()
        {
            int counter = 1;
            int x = 0;
            int y = 0;
            int lengthX = _width - 1;
            int lengthY = _height;

            while (!IsCompleted(counter))
            {
                // Down
                for (int i = 0; i < lengthY; i++)
                    _matrix[x, y++] = counter++;

                x++; y--; lengthY--;
                // Right
                for (int i = 0; i < lengthX; i++)
                    _matrix[x++, y] = counter++;

                x--; y--; lengthX--;
                //Up
                for (int i = 0; i < lengthY; i++)
                    _matrix[x, y--] = counter++;

                x--; y++; lengthY--;

                // Left
                for (int i = 0; i < lengthX; i++)
                    _matrix[x--, y] = counter++;

                x++; y++; lengthX--;
            }
        }
// Метод ToString() замість оцього методу.
        public void Print()
        {
            _generateMatrix();

            for (int y = 0; y < _height; y++)
            {
                for(int x = 0; x < _width; x++)
                    Console.Write(_matrix[x,y] + " ");
                Console.WriteLine();
            }
        }
    }
}
