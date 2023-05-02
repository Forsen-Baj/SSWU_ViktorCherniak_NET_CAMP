using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Оцінка 95 балів
namespace Home_task_6_3
{//Синтаксично все добре і відповідає умові задачі, але разом проаналізуємо ефективність.
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
