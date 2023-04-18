using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_5_2
{
    public class Department
    {
        public string name;
        private string prefix;
        public int width, height, depth;
        public List<Category> categories;
        

        public Department(string name, string prefix)
        {
            this.name = name;
            this.prefix = prefix;
            this.categories = new List<Category>();
            this.width = 0;
            this.height = 0;
            this.depth = 0;
        }

        public Department(Department department, string prefix)
        {
            this.name = department.name;
            this.prefix = prefix;
            this.categories = new List<Category>(department.categories);
            this.width = department.width;
            this.height = department.height;
            this.depth = department.depth;
        }

        public void AddCategory(Category _category)
        {
            categories.Add(new Category(_category, $"{this.prefix}/{this.name}"));

            this.width = Math.Max(this.width, _category.width);
            this.height = this.height + _category.height;
            this.depth = Math.Max(this.depth, _category.depth);
        }
        
        public void AddCategory(string name)
        {
            categories.Add(new Category(name, $"{prefix}/{this.name}"));
        }

        public (int w, int h, int d) Max()
        {
            foreach (Category category in categories)
            {
                this.width = Math.Max(this.width, category.width);
                this.height = this.height + category.height;
                this.depth = Math.Max(this.depth, category.depth);
            }
            return (this.width, this.height, this.depth);
        }

        public override string ToString()
        {
            string report = $"{prefix}/{name} [{width} * {height} * {depth}]:\n\t";
            report += String.Join("\n\t", categories);

            return report;
        }
    }
}
