using Home_task_4_3;

var db = new ApartmentDatabase();

string sample = "123 Test 22 Street LastName 1000 1010 17.04.22";
string sample2 = "123 Test 22 Street LastName 1020 1030 20.05.22";
string sample3 = "150 Test 22 Street Smith 999 1060 19.05.22";
string sample4 = "222 Sample street for ants Ronaldis 111 111 21.06.22";
// test string for console input - 404 Error street Admin 111 1000 25.06.22

db.AddElectricityRecord(sample, 2);
db.AddElectricityRecord(sample2, 2);
db.AddElectricityRecord(sample3, 2);
db.AddElectricityRecord(sample4, 2);

db.GetDBFromConsole();

Console.WriteLine(db.GetFullReport());
Console.WriteLine(db.GetOneEntry(123));
Console.WriteLine(db.FindMaxElectricityUser(0.2));
Console.WriteLine(db.HouseExpenses(0.2));
Console.WriteLine(String.Join("\n", db.FindUsersWithZeroConsumption()));