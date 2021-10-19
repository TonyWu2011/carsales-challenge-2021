using System.Collections.Generic;

namespace Example.Core.Models
{
    public class SalesPerson
    {
        public SalesPerson(string name)
        {
            Name = name;

            Groups = new List<SalesGroup>();
        }

        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public ICollection<SalesGroup> Groups { get; set; }
    }
}
