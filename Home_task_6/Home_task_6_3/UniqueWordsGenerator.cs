using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_6_3
{
    public class UniqueWordsGenerator
    {
        public IEnumerable<string> GetUniqueWords(string input)
        {
            HashSet<string> uniqueWords = new HashSet<string>();

            string[] words = input.Split(new char[] { ' ', '\t', '\r', '\n', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                uniqueWords.Add(word);
            }

            foreach (string word in uniqueWords)
            {
                yield return word;
            }
        }
    }
}
