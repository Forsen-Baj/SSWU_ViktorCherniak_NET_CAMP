using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10_1
{
    public class SharpPattern : IPatternGenerator
    {
        public string GetPattern()
        {
            var cardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>();

            var cardTypesPattern = string.Join("|", cardTypes.Select(cardType =>
            {
                var cardTypeString = cardType.ToString();

                var spacedCardTypeString = System.Text.RegularExpressions.Regex.Replace(cardTypeString, @"(\p{Lu}\p{Ll}*)(\p{Lu}\p{Ll}*)", "$1 $2");

                if (spacedCardTypeString == cardTypeString)
                {
                    return cardTypeString.Replace(" ", @"\s*");
                }

                return $"{cardTypeString}|{spacedCardTypeString.Replace(" ", @"\s*")}";
            }));

            return $@"#\s*({cardTypesPattern})\s*#\s*card_number\s*=\s*“(\d+)”";
        }
    }
}
