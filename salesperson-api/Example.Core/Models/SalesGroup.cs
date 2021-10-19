using System.Collections.Generic;

namespace Example.Core.Models
{
    public class SalesGroup
    {
        public SalesGroup(string name)
        {
            Name = name;

            Members = new List<SalesPerson>();
        }

        public string Name { get; set; }
        public ICollection<SalesPerson> Members { get; set; }
    }
}
