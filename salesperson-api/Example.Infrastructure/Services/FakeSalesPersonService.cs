using System.Collections.Generic;
using Example.Core.Models;
using Example.Core.Services;

namespace Example.Infrastructure.Services
{
    public class FakeSalesPersonService : ISalesPersonService
    {
        public IEnumerable<SalesPerson> List()
        {
            return new List<SalesPerson>
            {
                new SalesPerson {
                    Name = "John"
                },
                new SalesPerson {
                    Name = "Barney"
                }
            };
        }
    }

}