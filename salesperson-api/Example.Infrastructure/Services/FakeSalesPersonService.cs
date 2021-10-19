using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Core.Models;
using Example.Core.Services;
using Example.Persistence.Services;

namespace Example.Infrastructure.Services
{
    public class FakeSalesPersonService : ISalesPersonService
    {
        private IStorageService StorageService { get; }

        public FakeSalesPersonService(IStorageService storageService)
        {
            StorageService = storageService;
        }

        public Task<SalesPerson> AssignBestSalePersonAsync()
        {
            throw new System.NotImplementedException();
        }
    }

}