using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    class Log
    {
        public string TableName { get; set; }
        public DateTime Date { get; set; }
        public string OperationType { get; set; }
        public string NameRole { get; set; }
    }
}
