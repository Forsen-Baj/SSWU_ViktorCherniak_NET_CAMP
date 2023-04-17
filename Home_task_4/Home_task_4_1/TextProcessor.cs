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
        private string[] ClearAndSplitText(string text, string[] separators)
        {
            string clearText = text;
            clearText = clearText.Replace("\n", string.Empty);
            clearText = clearText.Replace("\r", string.Empty);
            clearText = clearText.Replace("\t", string.Empty);

            return clearText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
        public List<string> FindAllSentencesWithBrackets(string text)
        {
            string[] separators = { ".", "?", "!" };
            var sentences = ClearAndSplitText(text, separators);
            List<string> sentencesWithBrackets = new List<string>();

            foreach (string sentence in sentences)
                if (sentence.Contains("(") && sentence.Contains(")"))
                    sentencesWithBrackets.Add(sentence.Trim());

            return sentencesWithBrackets;
        }
    }
}
