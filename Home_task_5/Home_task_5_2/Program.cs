using Newtonsoft.Json;
using Home_task_5_2;
using System.Text.Json;
// У Вас тільки дворівнева структура. А рівнів може бути різна кількість(((
/*Box box = new Box("milk", "grocery", 10, 20, 30);
Category category = new Category("Grocery", "Shrek/kek");
category.AddBox(box);
category.AddBox(box);
Department department = new Department("kek", "Shrek");
department.AddCategory(category);
department.AddCategory(category);

var json  = JsonConvert.SerializeObject(department, Formatting.Indented);

Console.WriteLine(department);*/
//Console.WriteLine(json);

Shop shop = new Shop("Silpo");
shop.AddDepartment("Food Products");
shop.departments[0].AddCategory("Vegetables");
shop.departments[0].categories[0].AddItem("Carrot", 10, 15, 10);
shop.departments[0].categories[0].AddItem("Carrot", 11, 20, 10);
shop.departments[0].AddCategory("Diary");
shop.departments[0].categories[1].AddItem("Milk", 7, 5, 8);
shop.departments[0].categories[1].AddItem("Cream", 15, 20, 11);

Console.WriteLine(shop);
//Console.WriteLine(shop.ToJSON());
ConsoleShopParser parser = new ConsoleShopParser();
parser.CreateDepartment(shop);
Console.WriteLine(shop);
