using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    public class Product
    {

        public string Category { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int FoodValue { get; set; }
        public decimal Price { get; set; }

    }
}
