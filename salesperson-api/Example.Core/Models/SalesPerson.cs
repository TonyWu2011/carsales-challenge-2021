using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Example.Core.Models
{
    public class SalesPerson
    {
        public SalesPerson(string name)
        {
            Name = name;
            IsBusy = false;

            Groups = new List<SalesGroup>();
        }

        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public ICollection<SalesGroup> Groups { get; set; }
    }
}
