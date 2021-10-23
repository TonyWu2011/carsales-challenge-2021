using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public ICollection<SalesPerson> Members { get; set; }
    }
}
