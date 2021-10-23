using Example.Core.Enums;
using Example.Core.Services;
using Example.Core.Services.Persistence;
using Example.Infrastructure.Services;
using Example.Persistence.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Example.Persistence.Tests
{
    public class SalesPersonServiceTest
    {
        private IStorageService StorageService { get; }
        private ISalesGroupService SalesGroupService { get; }
        private ISalesPersonService SalesPersonService { get; }

        public SalesPersonServiceTest()
        {
            var persistenceStorageService = new JsonStorageService();
            StorageService = new MemoryStorageService(persistenceStorageService);

            SalesGroupService = new FakeSalesGroupSerivce(StorageService);
            SalesPersonService = new FakeSalesPersonService(StorageService, SalesGroupService);
        }

        [Fact]
        public async Task SalesPersonService_GetSalesPeopleAsync_NotNull()
        {
            var salesPerople = await SalesPersonService.GetSalesPeopleAsync();

            Assert.NotNull(salesPerople);
        }

        [Theory]
        [ClassData(typeof(SalesPersonServiceTestData))]
        public async Task SalesPersonService_AssignBestSalePersonAsync_NoOneIsBusy(CarType carType, LanguageOption languageOption)
        {
            var salesPerson = await SalesPersonService.AssignBestSalePersonAsync(carType, languageOption);

            switch (carType, languageOption)
            {
                case (CarType.Sport, LanguageOption.Greek):
                    Assert.NotNull(salesPerson);
                    Assert.Contains(salesPerson.Groups, x => x.Name == "A");
                    Assert.Contains(salesPerson.Groups, x => x.Name == "B");
                    break;

                case (CarType.Sport, LanguageOption.Other):
                case (CarType.Sport, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    Assert.Contains(salesPerson.Groups, x => x.Name == "B");
                    break;

                case (CarType.Family, LanguageOption.Greek):
                    Assert.NotNull(salesPerson);
                    Assert.Contains(salesPerson.Groups, x => x.Name == "A");
                    Assert.Contains(salesPerson.Groups, x => x.Name == "C");
                    break;

                case (CarType.Family, LanguageOption.Other):
                case (CarType.Family, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    Assert.Contains(salesPerson.Groups, x => x.Name == "C");
                    break;

                case (CarType.Tradie, LanguageOption.Greek):
                    Assert.NotNull(salesPerson);
                    Assert.Contains(salesPerson.Groups, x => x.Name == "A");
                    Assert.Contains(salesPerson.Groups, x => x.Name == "D");
                    break;

                case (CarType.Tradie, LanguageOption.Other):
                case (CarType.Tradie, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    Assert.Contains(salesPerson.Groups, x => x.Name == "D");
                    break;

                case (CarType.NotSpecified, LanguageOption.Greek):
                case (CarType.NotSpecified, LanguageOption.Other):
                case (CarType.NotSpecified, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    break;
            }

            // Reset memory
            await StorageService.ResetStorageAsync();
        }

        [Theory]
        [ClassData(typeof(SalesPersonServiceTestData))]
        public async Task SalesPersonService_AssignBestSalePersonAsync_NoGroupA(CarType carType, LanguageOption languageOption)
        {
            // Setup: set all group A to busy
            var salesGroups = await SalesGroupService.GetSalesGroupForLanguageAsync(LanguageOption.Greek);
            salesGroups.Members.ToList().ForEach(x => x.IsBusy = true);

            var salesPerson = await SalesPersonService.AssignBestSalePersonAsync(carType, languageOption);

            switch (carType, languageOption)
            {
                case (CarType.Sport, LanguageOption.Greek):
                    Assert.NotNull(salesPerson);
                    Assert.DoesNotContain(salesPerson.Groups, x => x.Name == "A");
                    Assert.Contains(salesPerson.Groups, x => x.Name == "B");
                    break;

                case (CarType.Sport, LanguageOption.Other):
                case (CarType.Sport, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    Assert.Contains(salesPerson.Groups, x => x.Name == "B");
                    break;

                    // Everyone in Group C (Family Car) are in Group A (Greek)
                case (CarType.Family, LanguageOption.Greek):
                case (CarType.Family, LanguageOption.Other):
                case (CarType.Family, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    break;

                case (CarType.Tradie, LanguageOption.Greek):
                    Assert.NotNull(salesPerson);
                    Assert.DoesNotContain(salesPerson.Groups, x => x.Name == "A");
                    Assert.Contains(salesPerson.Groups, x => x.Name == "D");
                    break;

                case (CarType.Tradie, LanguageOption.Other):
                case (CarType.Tradie, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    Assert.Contains(salesPerson.Groups, x => x.Name == "D");
                    break;

                case (CarType.NotSpecified, LanguageOption.Greek):
                case (CarType.NotSpecified, LanguageOption.Other):
                case (CarType.NotSpecified, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    break;
            }

            // Reset memory
            await StorageService.ResetStorageAsync();
        }

        [Theory]
        [ClassData(typeof(SalesPersonServiceTestData))]
        public async Task SalesPersonService_AssignBestSalePersonAsync_NoSalesPersonOfTheRequestedCarType(CarType carType, LanguageOption languageOption)
        {
            // Setup: set all everyone of the requested car type to busy
            var salesGroups = await SalesGroupService.GetSalesGroupForCarTypeAsync(carType);
            salesGroups?.Members.ToList().ForEach(x => x.IsBusy = true);

            var salesPerson = await SalesPersonService.AssignBestSalePersonAsync(carType, languageOption);

            switch (carType, languageOption)
            {
                case (CarType.Sport, LanguageOption.Greek):
                case (CarType.Sport, LanguageOption.Other):
                case (CarType.Sport, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    Assert.DoesNotContain(salesPerson.Groups, x => x.Name == "B");
                    break;

                case (CarType.Family, LanguageOption.Greek):
                case (CarType.Family, LanguageOption.Other):
                case (CarType.Family, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    Assert.DoesNotContain(salesPerson.Groups, x => x.Name == "C");
                    break;

                case (CarType.Tradie, LanguageOption.Greek):
                case (CarType.Tradie, LanguageOption.Other):
                case (CarType.Tradie, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    Assert.DoesNotContain(salesPerson.Groups, x => x.Name == "D");
                    break;

                case (CarType.NotSpecified, LanguageOption.Greek):
                case (CarType.NotSpecified, LanguageOption.Other):
                case (CarType.NotSpecified, LanguageOption.NotSpecified):
                    Assert.NotNull(salesPerson);
                    break;
            }

            // Reset memory
            await StorageService.ResetStorageAsync();
        }

        [Theory]
        [ClassData(typeof(SalesPersonServiceTestData))]
        public async Task SalesPersonService_AssignBestSalePersonAsync_EveryoneIsBusy(CarType carType, LanguageOption languageOption)
        {
            // Setup: everyone to busy
            var salesPeople = await SalesPersonService.GetSalesPeopleAsync();
            salesPeople.ToList().ForEach(x => x.IsBusy = true);

            var salesPerson = await SalesPersonService.AssignBestSalePersonAsync(carType, languageOption);

            Assert.Null(salesPerson);

            // Reset memory
            await StorageService.ResetStorageAsync();
        }

        private class SalesPersonServiceTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { CarType.Sport, LanguageOption.Greek };
                yield return new object[] { CarType.Sport, LanguageOption.Other };
                yield return new object[] { CarType.Sport, LanguageOption.NotSpecified };

                yield return new object[] { CarType.Family, LanguageOption.Greek };
                yield return new object[] { CarType.Family, LanguageOption.Other };
                yield return new object[] { CarType.Family, LanguageOption.NotSpecified };

                yield return new object[] { CarType.Tradie, LanguageOption.Greek };
                yield return new object[] { CarType.Tradie, LanguageOption.Other };
                yield return new object[] { CarType.Tradie, LanguageOption.NotSpecified };

                yield return new object[] { CarType.NotSpecified, LanguageOption.Greek };
                yield return new object[] { CarType.NotSpecified, LanguageOption.Other };
                yield return new object[] { CarType.NotSpecified, LanguageOption.NotSpecified };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
