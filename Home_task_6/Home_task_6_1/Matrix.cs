using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

    public override string ToString()
    {
        int n = matrix.GetLength(0);
        StringBuilder sb = new StringBuilder();

        for (int y = 0; y < n; y++)
        {
            sb.Append("\n");

            for (int x = 0; x < n; x++)
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