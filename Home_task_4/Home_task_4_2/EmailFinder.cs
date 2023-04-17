using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Home_task_4_2
{
    internal class EmailFinder
    {
        public List<string> FindAllWordsWithAt(string text)
        {
            var words = text.Split(new char[] {' ', ','}, StringSplitOptions.TrimEntries)
                      .Where(word => word.Contains("@"));

            var wordsWithAt = new List<string>();

            foreach (var word in words)
            {
                wordsWithAt.Add(word);
            }

            return wordsWithAt;
        }

        public List<string> FindAllValidEmails(string text)
        {
            var possbileEmails = FindAllWordsWithAt(text);
            var validEmails = new List<string>();

            foreach(var email in  possbileEmails)
            {
                if (IsValidEmail(email))
                {
                    validEmails.Add(email);
                }
            }
            return validEmails;
        }
        public bool IsValidEmail(string email)
        {
            if (email.Length > 254)
            {
                return false;
            }

            if (email.Count(c => c == '@') != 1)
            {
                return false;
            }

            if (email.Any(c => c < 33))
            {
                return false;
            }

            var parts = email.Split('@');

            if (parts.Length != 2)
            {
                return false;
            }

            string local = parts[0];
            string domain = parts[1];

            if (local.Length > 63)
            {
                return false;
            }

            if (domain.Length > 254)
            {
                return false;
            }

            // Ignore comment
            if (domain.Contains("("))
            {
                domain = Regex.Replace(domain, @" ?\(.*?\)", string.Empty);
            }

            if (local.StartsWith('.') || local.EndsWith('.'))
            {
                return false;
            }

            if (!domain.Contains('.'))
            {
                return false;
            }

            if (!domain.All(c => Char.IsLetterOrDigit(c) || c == '-' || c == '.' || c == '[' || c == ']' || c == ':'))
            {
                return false;
            }

            if (local.Any(c => c == ',' || c == ':' || c == ';' || c == '<' || c == '>' || c == '[' || c == ']' || c == '\\' ))
            {
                return false;
            }

            return true;
        }
    }
}
