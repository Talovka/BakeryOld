using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    public class Kiosk
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOpen { get; set; }
        public string Owner { get; set; }

        public string BakeryName { get; set; }
    }
}
