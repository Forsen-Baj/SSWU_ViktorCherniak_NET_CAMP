using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Home_task_3_2
{
    public class StringWorker
    {
        //Find index of n-th substring in text
        public int? IndexOfN(string text, string subString, int n)
        {
            if (n < 1)
                return null;

            int lastPos = text.IndexOf(subString);

            for (int i = 1; i <= n && lastPos != -1; i++)
            {
                if (i == n)
                    return lastPos;
                lastPos = text.IndexOf(subString, lastPos + subString.Length);
            }

            return null;
        }

        public int? SecondIndexOf(string text, string subString)
        {
            return IndexOfN(text, subString, 2);
        }

        public int CountCapitalLetterWords(string text, char separator = ' ')
        {
            string[] words = text.Split(separator);

            var capitalizedWords = words.Where(w => !string.IsNullOrEmpty(w) && char.IsUpper(w[0]));

            return capitalizedWords.Count();
        }

        public string ReplaceWordsWithDoubleLetters(string text, string replacement)
        {
            Regex regex = new Regex(@"\b\w*(\w)\1\w*\b");
            string newText = regex.Replace(text, replacement);
            return newText;
        }

    }
}
