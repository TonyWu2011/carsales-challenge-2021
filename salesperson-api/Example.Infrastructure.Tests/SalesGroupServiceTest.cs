using Example.Core.Enums;
using Example.Core.Services;
using Example.Infrastructure.Services;
using Example.Persistence.Services;
using System.Threading.Tasks;
using Xunit;

namespace Example.Infrastructure.Tests
{
    public class SalesGroupServiceTest
    {
        private ISalesGroupService SalesGroupService { get; }

        public SalesGroupServiceTest()
        {
            var persistenceStorageService = new JsonStorageService();
            var storageService = new MemoryStorageService(persistenceStorageService);
            SalesGroupService = new FakeSalesGroupSerivce(storageService);
        }

        [Fact]
        public async Task SalesGroupService_GetSalesGroupsAsync_NotNull()
        {
            var salesGroups = await SalesGroupService.GetSalesGroupsAsync();

            Assert.NotNull(salesGroups);
        }

        [Theory]
        [InlineData(CarType.Sport)]
        [InlineData(CarType.Family)]
        [InlineData(CarType.Tradie)]
        [InlineData(CarType.NotSpecified)]
        public async Task SalesGroupService_GetSalesGroupForCarTypeAsync(CarType carType)
        {
            var saleGroup = await SalesGroupService.GetSalesGroupForCarTypeAsync(carType);

            switch (carType)
            {
                case CarType.Sport:
                    Assert.NotNull(saleGroup);
                    Assert.Equal("B", saleGroup.Name);
                    break;

                case CarType.Family:
                    Assert.NotNull(saleGroup);
                    Assert.Equal("C", saleGroup.Name);
                    break;

                case CarType.Tradie:
                    Assert.NotNull(saleGroup);
                    Assert.Equal("D", saleGroup.Name);
                    break;

                case CarType.NotSpecified:
                    Assert.Null(saleGroup);
                    break;
            }
        }

        [Theory]
        [InlineData(LanguageOption.Greek)]
        [InlineData(LanguageOption.Other)]
        [InlineData(LanguageOption.NotSpecified)]
        public async Task SalesGroupService_GetSalesGroupForLanguageAsync(LanguageOption languageOption)
        {
            var saleGroup = await SalesGroupService.GetSalesGroupForLanguageAsync(languageOption);

            switch (languageOption)
            {
                case LanguageOption.Greek:
                    Assert.NotNull(saleGroup);
                    Assert.Equal("A", saleGroup.Name);
                    break;

                case LanguageOption.Other:
                case LanguageOption.NotSpecified:
                    Assert.Null(saleGroup);
                    break;
            }
        }
    }
}
