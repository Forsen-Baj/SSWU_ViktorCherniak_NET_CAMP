using Home_task_6_3;

string input = "hello; world goodbye world hello,        again ";

UniqueWordsGenerator generator = new UniqueWordsGenerator();

foreach (string word in generator.GetUniqueWords(input))
{
    Console.WriteLine(word);
}