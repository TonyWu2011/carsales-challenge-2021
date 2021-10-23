using System.Collections.Generic;

namespace Example.Core.Models.Persistence
{
    public class JsonSalesPerson
    {
        public string Name { get; set; }
        public ICollection<string> Groups { get; set; }
    }
}
