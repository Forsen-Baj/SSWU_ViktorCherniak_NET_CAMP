using Home_task_4_2;

string englishText = @"Lorem ipsum 
dolor 
sit amet, consectetur adipiscing (elit), sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea 
commodo consequat. Duis @aute irure dolor in reprehenderit in voluptate velit esse 
cillum dolore eu fugiat nulla pariatur. @Excepteur sint occaecat cupidatat non


proident, sunt in (culpa) qui officia deserunt mollit anim id est laborum.
Random text to check email hello@world.com very.common@example.com 
disposable.style.email.with+symbol@example.com 
other.email-with-hyphen@example.com 
fully-qualified-domain@example.com user.name+tag+sorting@example.com x@example.com 
example-indeed@strange-example.com test/test@test.com 
example@s.example postmaster@[123.123.123.123] 
example@(test)hello.com A@b@c@example.com ab(c)d,e:f;g<h>i[j\k]l@example.com 
1234567890123456789012345678901234567890123456789012345678901234+x@example.com
i_like_underscore@but_its_not_allowed_in_this_part.example.com QA[icon]CHOCOLATE[icon]@test.com
";

var emailFinder = new EmailFinder();
Console.WriteLine(String.Join("\n", emailFinder.FindAllWordsWithAt(englishText)));
Console.WriteLine("\n\nEMAILS\n\n");
Console.WriteLine(String.Join("\n", emailFinder.FindAllValidEmails(englishText)));
