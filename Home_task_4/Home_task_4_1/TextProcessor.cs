using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_4_1
{
    public class TextProcessor
    {
        public List<string> FindAllSentencesWithBrackets(string text)
        {
            string clearText = text;
            clearText = clearText.Replace("\n", String.Empty);
            clearText = clearText.Replace("\r", String.Empty);
            clearText = clearText.Replace("\t", String.Empty);

            string[] separators = { ".", "?", "!" };
            string[] sentences = clearText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<string> sentencesWithBrackets = new List<string>();

            foreach (string sentence in sentences)
            {
                if (sentence.Contains("(") && sentence.Contains(")"))
                {
                    sentencesWithBrackets.Add(sentence.Trim());
                }
            }

            return sentencesWithBrackets;

        }
    }
}
