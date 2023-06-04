using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Home_task_10_1
{
    public class CardProcessor
    {
        private Dictionary<CardType, List<string>> cardStarters;
        private Dictionary<CardType, List<int>> cardLength;
        private string cardPattern;
        public CardProcessor(string settingsPath, IPatternGenerator patternGenerator)
        {
            cardStarters = new Dictionary<CardType, List<string>>();
            cardLength = new Dictionary<CardType, List<int>>();
            LoadDataFromYaml(settingsPath);
            cardPattern = patternGenerator.GetPattern();
        }

        private class CardTypeInfo
        {
            public List<string> cardStarters { get; set; }
            public List<int> cardLength { get; set; }
        }

        public void LoadDataFromYaml(string filePath)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var yamlObject = deserializer.Deserialize<Dictionary<string, CardTypeInfo>>(File.ReadAllText(filePath));

            foreach (var card in yamlObject)
            {
                CardType cardType;
                if (Enum.TryParse(card.Key.Replace(" ", ""), out cardType))
                {
                    cardStarters[cardType] = card.Value.cardStarters;
                    cardLength[cardType] = card.Value.cardLength;
                }
                else
                {
                    throw new Exception($"Unknown card type {card.Key} in YAML file");
                }
            }
        }

        public Dictionary<CardType, List<string>> GetCardDetailsFromFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            string pattern = cardPattern;

            Regex rg = new Regex(pattern);
            MatchCollection matchedCards = rg.Matches(fileContent);

            var cardDetails = new Dictionary<CardType, List<string>>();

            foreach (Match card in matchedCards)
            {
                var cardType = Enum.Parse<CardType>(card.Groups[1].Value.Replace(" ", ""));
                var cardNumber = card.Groups[2].Value;

                if (cardDetails.ContainsKey(cardType))
                {
                    cardDetails[cardType].Add(cardNumber);
                }
                else
                {
                    cardDetails[cardType] = new List<string> { cardNumber };
                }
            }

            return cardDetails;
        }

        public Dictionary<string, bool> ValidateCards(Dictionary<CardType, List<string>> cardsToValidate)
        {
            var validationResults = new Dictionary<string, bool>();

            foreach (var cardGroup in cardsToValidate)
            {
                var cardType = cardGroup.Key;

                if (!cardStarters.TryGetValue(cardType, out var validStarters))
                    throw new Exception($"No starters found for card type {cardType}");
                if (!cardLength.TryGetValue(cardType, out var validLengths))
                    throw new Exception($"No lengths found for card type {cardType}");

                foreach (var cardNumber in cardGroup.Value)
                {
                    // Check if the card number starts with any of the valid starters
                    bool startsWithValidStarter = validStarters.Any(starter => cardNumber.StartsWith(starter.ToString()));

                    // Check if the card number length matches any of the valid lengths
                    bool hasValidLength = validLengths.Contains(cardNumber.Length);

                    // Validate the card number with Luhn algorithm
                    bool isValidLuhn = Luhn.Validate(cardNumber);

                    // If all checks pass, the card number is valid
                    validationResults[cardNumber] = startsWithValidStarter && hasValidLength && isValidLuhn;
                }
            }

            return validationResults;
        }
    }
}