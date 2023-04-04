using Home_task_3_2;

StringWorker sw  = new StringWorker();

string text = "abc Abc   ,   abc, aa123 class programm hello book class bomb";
Console.WriteLine(sw.IndexOfN(text, "ab", 3));
Console.WriteLine(sw.SecondIndexOf(text, "c"));
Console.WriteLine(sw.CountCapitalLetterWords(text));
Console.WriteLine(sw.ReplaceWordsWithDoubleLetters(text, "HAHA"));

