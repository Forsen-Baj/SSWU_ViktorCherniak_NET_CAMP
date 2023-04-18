using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Home_task_5_2
{
    public class Box
    {
        public string name;
        private string prefix;
        public int width, height, depth;

        public Box(string name, string prefix, int width, int height, int depth)
        {
            this.name = name;
            this.prefix = prefix;
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public override string ToString()
        {
            return $"{prefix}/{name}; [{width} * {height} * {depth}]";
        }

    }
}
