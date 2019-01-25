using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.OData
{
    public class Color
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Product product { get; set; }
    }
}
