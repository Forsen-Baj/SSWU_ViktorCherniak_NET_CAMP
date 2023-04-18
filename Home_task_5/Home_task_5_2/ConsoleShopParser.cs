using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_5_2
{
    public class ConsoleShopParser
    {
        public void CreateDepartment(Shop shop)
        {
            Console.WriteLine("Type name for department");
            var result = Console.ReadLine();
            shop.AddDepartment(result);
            Console.WriteLine($"Department {result} created.");

            var link = shop.departments[shop.departments.Count - 1];
            Console.WriteLine($"How many categories it should have?");
            var n = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Type name for category {i}:");
                link.AddCategory(Console.ReadLine());
            }
            Console.WriteLine($"{n} categories created");

            Console.WriteLine("Adding items to categories");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"How many items should category {link.categories[i].name} have?");
                int itemsN = Int32.Parse(Console.ReadLine());
                for (int j = 0; j < itemsN; j++)
                {
                    Console.WriteLine($"Enter {i} item name");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Enter size as \"width height depth\" i.e 10 20 30");
                    string[] size = Console.ReadLine().Split(" ");
                    link.categories[i].AddItem(name, Int32.Parse(size[0]), Int32.Parse(size[1]), Int32.Parse(size[2]));
                    Console.WriteLine($"Item {name} added");
                }
            }


        }
    }
}
