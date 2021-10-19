using System.Collections.Generic;
using Example.Core.Models;

namespace Example.Core.Services
{
    public interface ISalesPersonService
    {
        IEnumerable<SalesPerson> List();
    }

}