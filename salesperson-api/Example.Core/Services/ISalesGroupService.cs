using Example.Core.Enums;
using Example.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Core.Services
{
    public interface ISalesGroupService
    {
        public Task<ICollection<SalesGroup>> GetSalesGroupsAsync();
        public Task<SalesGroup> GetSalesGroupForCarTypeAsync(CarType carType);
        public Task<SalesGroup> GetSalesGroupForLanguageAsync(LanguageOption languageOption);
    }
}
