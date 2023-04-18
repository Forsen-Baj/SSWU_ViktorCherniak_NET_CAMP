using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_5_2
{
    public class Shop
    {
        public string name;
        public int width, height, depth;
        public List<Department> departments;
        

        public Shop(string name)
        {
            this.name = name;
            this.departments = new List<Department>();
            this.width = 0;
            this.height = 0;
            this.depth = 0;
        }

        public void AddDepartment(Department _department)
        {
            Department department = new Department(_department, $"{name}/");
            this.departments.Add(department);

            this.width = Math.Max(this.width, department.width);
            this.height = this.height + department.height;
            this.depth = Math.Max(this.depth, department.depth);
        }

        public void AddDepartment(string name)
        {
            Department department = new Department(name, $"{this.name}");
            this.departments.Add(department);
        }

        public override string ToString()
        {
            foreach (Department department in this.departments)
            {
                department.Max();

                this.width = Math.Max(this.width, department.width);
                this.height = this.height + department.height;
                this.depth = Math.Max(this.depth, department.depth);
            }

            string report = $"{name} [{width} * {height} * {depth}]:\n\t";
            report += String.Join("\n\t", departments);

            return report;
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
