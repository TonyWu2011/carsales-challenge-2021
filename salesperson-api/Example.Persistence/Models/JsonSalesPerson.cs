using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Persistence.Models
{
    public class JsonSalesPerson
    {
        public string Name { get; set; }
        public ICollection<string> Groups { get; set; }
    }
}
