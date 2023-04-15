using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_4_2
{
    internal class EmailFinder
    {
        public List<string> FindAllWordsWithAt(string text)
        {
            var words = text.Split(new char[] {' ', ','})
                      .Where(word => word.Contains("@"));

            var wordsWithAt = new List<string>();

            foreach (var word in words)
            {
                wordsWithAt.Add(word);
            }

            return wordsWithAt;
        }
        public bool IsValidEmail(string email)
        {
            if (email.Length > 254)
            {
                Console.WriteLine(email + "RULE1");
                return false;
            }

            if (email.Count(c => c == '@') != 1)
            {
                Console.WriteLine(email + "RULE2");
                return false;
            }

            if (email.Any(c => c < 33))
            {
                Console.WriteLine(email + "RULE3");
                return false;
            }

            return true;
        }
    }
}
