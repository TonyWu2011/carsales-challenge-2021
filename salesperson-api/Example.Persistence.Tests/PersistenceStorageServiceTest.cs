using Example.Core.Services.Persistence;
using Example.Persistence.Services;
using System.Threading.Tasks;
using Xunit;

namespace Example.Persistence.Tests
{
    public class PersistenceStorageServiceTest
    {
        private IPersistenceStorageService PersistenceStorageService { get; }

        public PersistenceStorageServiceTest()
        {
            PersistenceStorageService = new JsonStorageService();
        }

        [Fact]
        public async Task JsonStorageService_GetDataFromPersistenceAsync_NotNull()
        {
            var storage = await PersistenceStorageService.GetDataFromPersistenceAsync();

            Assert.NotNull(storage);
            Assert.NotNull(storage.SalesPeople);
            Assert.NotNull(storage.SalesGroups);
        }

        [Fact]
        public async Task JsonStorageService_GetDataFromPersistenceAsync_NotEmpty()
        {
            var storage = await PersistenceStorageService.GetDataFromPersistenceAsync();

            Assert.NotEmpty(storage.SalesPeople);
            Assert.NotEmpty(storage.SalesGroups);
        }
    }
}
