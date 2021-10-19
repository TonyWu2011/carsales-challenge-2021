using Example.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Persistence.Services
{
    public interface IStorageService
    {
        public Task ResetStorageAsync();
        public Task<ICollection<SalesPerson>> GetSalesPeopleAsync();
        public Task<ICollection<SalesGroup>> GetSalesGroupsAsync();
    }
}
