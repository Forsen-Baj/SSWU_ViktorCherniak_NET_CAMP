using Home_task_10_1;

SharpPattern pattern = new SharpPattern();
var processor = new CardProcessor("settings.yml", pattern);
var cards = processor.GetCardDetailsFromFile("cards.txt");
var vaildCards = processor.ValidateCards(cards);

foreach (var kvp in cards)
{
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, String.Join(" ", kvp.Value));
}
Console.WriteLine();

foreach (var kvp in vaildCards)
{
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, String.Join(" ", kvp.Value));
}

