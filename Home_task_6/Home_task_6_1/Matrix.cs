using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Home_task_6_1
{
    public class Matrix : IEnumerable<int>
    {
        private int[,] matrix;

        public Matrix(int size)
        {
            matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = i * size + j + 1;
                }
            }
        }

        public Matrix(int[,] array)
        {
            matrix = new int[array.GetLength(0), array.GetLength(1)];
            Array.Copy(array, matrix, array.Length);
        }

        public Matrix(List<List<int>> list)
        {
            int rows = list.Count;
            int cols = list[0].Count;
            matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = list[i][j];
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                sb.Append("\n");

                for (int x = 0; x < matrix.GetLength(0); x++)
                    sb.Append(matrix[x, y] + " ");
            }

            sb.Append("\n");
            return sb.ToString();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int i = 0;
            int j = 0;
            int count = 0;

            while (count < rows * cols)
            {
                yield return matrix[i, j];

                if ((i + j) % 2 == 0) // moving up
                {
                    if (j == cols - 1)
                    {
                        i++;
                    }
                    else if (i == 0)
                    {
                        j++;
                    }
                    else
                    {
                        i--;
                        j++;
                    }
                }
                else // moving down
                {
                    if (i == rows - 1)
                    {
                        j++;
                    }
                    else if (j == 0)
                    {
                        i++;
                    }
                    else
                    {
                        i++;
                        j--;
                    }
                }

                count++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}