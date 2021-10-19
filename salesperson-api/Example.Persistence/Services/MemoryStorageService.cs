using Example.Core.Models;
using Example.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Persistence.Services
{
    public class MemoryStorageService : IStorageService
    {
        private MemoryStorage MemoryStorage { get; set; }

        private IPersistenceStorageService PersistenceStorageService { get; set; }

        public MemoryStorageService(IPersistenceStorageService persistenceStorageService)
        {
            PersistenceStorageService = persistenceStorageService;
        }

        public async Task<ICollection<SalesPerson>> GetSalesPeopleAsync()
        {
            if (MemoryStorage == null)
            {
                await ResetStorageAsync();
            }

            return MemoryStorage.SalesPeople;
        }

        public async Task<ICollection<SalesGroup>> GetSalesGroupsAsync()
        {
            if (MemoryStorage == null)
            {
                await ResetStorageAsync();
            }

            return MemoryStorage.SalesGroups;
        }

        public async Task ResetStorageAsync()
        {
            MemoryStorage = await PersistenceStorageService.GetDataFromPersistenceAsync();
        }
    }
}
