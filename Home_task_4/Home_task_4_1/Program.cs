using Home_task_4_1;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

string ukrainianText = @"Звичайно, радіо стало однією з найбільш популярних форм масової інформації.
На сьогоднішній день радіо передає різноманітні 
програми: музику, новини, (спорт), розважальні шоу, ток-шоу тощо.
Радіо можна 
слухати в (автомобілі)
, вдома або на @вулиці з допомогою різних пристроїв: радіоприймачів, телефонів, планшетів, ноутбуків.
За допомогою @радіо можна отримати важл
иву інформацію про події у світі та в Україні.
Також радіо може бути використане як засіб розваги та відпочинку, наприклад, під час довгих поїздок або на відпочинку на природі.
Багато (радіостанцій пропонують ефір) зі спеціальними програмами для дітей, де можна послухати цікаві казки та ігри.
Нині, в епоху інтернету, радіо продовжує бути популярним серед населення.
Україна має багато власних (радіостанцій), які передають різноманітні @програми та музику.
Радіо допомагає людям почуватися більш об'єднаними, слухаючи новини та програми з різних куточків країни.";

string englishText = @"Lorem ipsum 
dolor 
sit amet, consectetur adipiscing (elit), sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea 
commodo consequat. Duis @aute irure dolor in reprehenderit in voluptate velit esse 
cillum dolore eu fugiat nulla pariatur. @Excepteur sint occaecat cupidatat non


proident, sunt in (culpa) qui officia deserunt mollit anim id est laborum.
Random text to check email hello@world.com";

string sampleText = "Hi @JohnDoe, how are you doing? Have you met @JaneDoe yet? hello@world. Please contact support@mycompany.com for further assistance. You can also follow us on Twitter at @MyCompany for updates.";


var textProcessor = new TextProcessor();

var sentences = textProcessor.FindAllSentencesWithBrackets(ukrainianText);
Console.WriteLine(String.Join("\n", sentences));

Console.WriteLine( "\n\n");

sentences = textProcessor.FindAllSentencesWithBrackets(englishText);
Console.WriteLine(String.Join("\n", sentences));

Console.WriteLine("\n\n");

sentences = textProcessor.FindAllWordsWithAt(sampleText);
Console.WriteLine(String.Join("\n", sentences));
