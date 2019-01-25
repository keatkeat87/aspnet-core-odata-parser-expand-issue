using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.OData
{
    public class Product
    {
        public int Id { get; set; }
        public string code { get; set; }
        public List<Color> colors { get; set; }
    }
}
