using System.Collections.Generic;
using System.Linq;

namespace Example.Core.Models.DTOs
{
    public class SalesPersonDTO
    {
        public SalesPersonDTO(SalesPerson salesPerson)
        {
            Name = salesPerson.Name;
            IsBusy = salesPerson.IsBusy;
            Groups = salesPerson.Groups.Select(x => x.Name).ToList();
        }

        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public ICollection<string> Groups { get; set; }
    }
}
