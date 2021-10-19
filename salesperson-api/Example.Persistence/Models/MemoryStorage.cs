using Example.Core.Models;
using System.Collections.Generic;

namespace Example.Persistence.Models
{
    public class MemoryStorage
    {
        public MemoryStorage(ICollection<SalesPerson> salesPeople, ICollection<SalesGroup> salesGroups)
        {
            SalesPeople = salesPeople;
            SalesGroups = salesGroups;
        }

        public ICollection<SalesPerson> SalesPeople { get; }
        public ICollection<SalesGroup> SalesGroups { get; }
    }
}
