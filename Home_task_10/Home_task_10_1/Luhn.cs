using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10_1
{
    public static class Luhn
    {
        public static int CheckSum(string number)
        {
            int sum = 0;

            for (int i = number.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (!char.IsDigit(number[i])) return -1;

                int digit = number[i] - '0';

                if (j % 2 == 1)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9; 
                }

                sum += digit;
            }

            return sum;
        }

        public static bool Validate(string number)
        {
            int checkSum = CheckSum(number);
            return checkSum >= 0 && checkSum % 10 == 0;
        }
    }
}
