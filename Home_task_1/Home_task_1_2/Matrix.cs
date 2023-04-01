using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_1_2
{
    internal class Matrix
    {
        public List<string> Lines;
        (int, int) _maxLineStart;
        (int, int) _maxLineEnd;
        int _maxLineColor;
        int _maxLineLength;

        public Matrix()
        {
            Lines = new List<string>();
            _maxLineColor = 0;
            _maxLineLength = 0;
            _maxLineStart = (0, 0);
            _maxLineEnd = (0, 0);
        }

        void AddMaxLineStats(int color, int length, int xStart, int xEnd, int y)
        {
            _maxLineColor = color;
            _maxLineLength = length;
            _maxLineStart = (xStart, y);
            _maxLineEnd = (xEnd, y);
        }

        void FindLongestLine()
        {
            int lineCounter = 0;

            foreach (var Line in Lines)
            {
                var line = Line?.Split(' ').Select(Int32.Parse).ToList();
                int currentColor = -1;
                int length = 0;
                int xStart = 0;

                for (int i = 0; i < line.Count; i++)
                    if (currentColor == line[i])
                    {
                        length++;
                    }
                    else
                    {
                        if (length > _maxLineLength)
                            AddMaxLineStats(currentColor, length, xStart, i - 1, lineCounter);

                        currentColor = line[i];
                        length = 1;
                        xStart = i;
                    }
                if (length > _maxLineLength)
                    AddMaxLineStats(currentColor, length, xStart, line.Count - 1, lineCounter);

                lineCounter++;
            }
        }
// Не зрозуміла світлої ідеї, навіщо матрицю переганяти в довгу стрічку символів. Треба поспілкуватись після пари.
        public void GenerateRandomMatrix(int height, int width)
        {
            Lines = new List<string>();

            Random rand = new Random();
            
            for (int line = 0; line < height; line++)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < width; i++)
                {
                    int randomNum = rand.Next(0, 17);
                    sb.Append(randomNum.ToString() + " ");
                }

                string s = sb.ToString().Remove(sb.Length -1);
                Lines.Add(s);
            }
        }

        public void PrintMatrix()
        {
            foreach (var line in Lines)
                Console.WriteLine(line);
        }

        public string MaxLineStats()
        {
            FindLongestLine();
            return "Longest line: start" + _maxLineStart.ToString() + "; end" + _maxLineEnd.ToString() + '\n' +
                    "Color: " + _maxLineColor.ToString() + "; Length: " + _maxLineLength.ToString();
        }


    }
}
