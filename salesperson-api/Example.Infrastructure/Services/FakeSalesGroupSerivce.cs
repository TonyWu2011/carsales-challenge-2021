using Example.Core.Enums;
using Example.Core.Models;
using Example.Core.Services;
using Example.Core.Services.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Infrastructure.Services
{
    public class FakeSalesGroupSerivce : ISalesGroupService
    {
        private IStorageService StorageService { get; }

        public FakeSalesGroupSerivce(IStorageService storageService)
        {
            StorageService = storageService;
        }

        public async Task<ICollection<SalesGroup>> GetSalesGroupsAsync()
        {
            return await StorageService.GetSalesGroupsAsync();
        }

        public async Task<SalesGroup> GetSalesGroupForCarTypeAsync(CarType carType)
        {
            var salesGroups = await StorageService.GetSalesGroupsAsync();

            return carType switch
            {
                CarType.Sport => salesGroups.FirstOrDefault(x => x.Name == "B"),
                CarType.Family => salesGroups.FirstOrDefault(x => x.Name == "C"),
                CarType.Tradie => salesGroups.FirstOrDefault(x => x.Name == "D"),
                CarType.NotSpecified => null,
                _ => null,
            };
        }

        public async Task<SalesGroup> GetSalesGroupForLanguageAsync(LanguageOption languageOption)
        {
            var salesGroups = await StorageService.GetSalesGroupsAsync();

            return languageOption switch
            {
                LanguageOption.Greek => salesGroups.FirstOrDefault(x => x.Name == "A"),
                LanguageOption.Other or LanguageOption.NotSpecified => null,
                _ => null,
            };
        }
    }
}
