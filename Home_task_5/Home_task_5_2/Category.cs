using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_5_2
{
    public class Category
    {
        public string name;
        private string prefix;
        public int width, height, depth;
        public List<Box> items;
        

        public Category(string name, string prefix)
        {
            this.name = name;
            this.prefix = prefix;
            this.items = new List<Box>();
            this.width = 0;
            this.height = 0;
            this.depth = 0;
        }

        public Category(Category category, string prefix)
        {
            this.items = new List<Box>(category.items);
            this.prefix = prefix;
            this.name = category.name;
            this.width = category.width;
            this.height = category.height;
            this.depth = category.depth;
        }

        public void AddItem(string name, int width, int height, int depth)
        {
            Box item = new Box(name, $"{prefix}/{this.name}", width, height, depth);
            items.Add(item);

            this.width = Math.Max(this.width, width);
            this.height = this.height + height;
            this.depth = Math.Max(this.depth, depth);
        }

        public void AddBox(Box box)
        {
            Box item = new Box(box.name, $"{prefix}/{this.name}", box.width, box.height, box.depth);
            items.Add(item);

            this.width = Math.Max(this.width, box.width);
            this.height = this.height + box.height;
            this.depth = Math.Max(this.depth, box.depth);
        }

        public (int w, int h, int d) Max()
        {
            foreach (Box box in items)
            {
                this.width = Math.Max(this.width, box.width);
                this.height = this.height + box.height;
                this.depth = Math.Max(this.depth, box.depth);
            }
            return (this.width, this.height, this.depth);
        }

        public override string ToString()
        {
            string report = $"{prefix}/{name} [{width} * {height} * {depth}]:\n\t\t";
            report += String.Join("\n\t\t", items);

            return report;
        }
    }
}
