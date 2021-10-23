using Example.Core.Services.Persistence;
using Example.Persistence.Services;
using System.Threading.Tasks;
using Xunit;

namespace Example.Persistence.Tests
{
    public class StorageServiceTests
    {
        private IStorageService StorageService { get; }

        public StorageServiceTests()
        {
            var persistenceStorageService = new JsonStorageService();
            StorageService = new MemoryStorageService(persistenceStorageService);
        }

        [Fact]
        public async Task StorageService_GetSalesPeopleAsync_NotEmpty()
        {
            var salesPeople = await StorageService.GetSalesPeopleAsync();

            Assert.NotNull(salesPeople);
            Assert.NotEmpty(salesPeople);
        }

        [Fact]
        public async Task StorageService_GetSalesGroupsAsync_NotEmpty()
        {
            var salesGroups = await StorageService.GetSalesGroupsAsync();

            Assert.NotNull(salesGroups);
            Assert.NotEmpty(salesGroups);
        }
    }
}
