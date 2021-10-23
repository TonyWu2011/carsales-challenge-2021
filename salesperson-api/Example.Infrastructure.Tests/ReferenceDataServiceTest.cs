using Example.Core.Enums;
using Example.Core.Services;
using Example.Infrastructure.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Example.Persistence.Tests
{
    public class ReferenceDataServiceTest
    {
        private IReferenceDataService ReferenceDataService { get; }

        public ReferenceDataServiceTest()
        {
            ReferenceDataService = new ReferenceDataService();
        }

        [Fact]
        public async Task ReferenceDataService_GetReferenceDataAsync_NotNull()
        {
            var referenceData = await ReferenceDataService.GetReferenceDataAsync();

            Assert.NotNull(referenceData);
            Assert.NotEmpty(referenceData.CarTypes);
            Assert.NotEmpty(referenceData.LanguageOptions);
        }

        [Fact]
        public async Task ReferenceDataService_GetReferenceDataAsync_ContainAllEnums()
        {
            var referenceData = await ReferenceDataService.GetReferenceDataAsync();

            Assert.Equal(Enum.GetValues<CarType>().ToDictionary(x => (int)x, x => x.ToString()), referenceData.CarTypes);
            Assert.Equal(Enum.GetValues<LanguageOption>().ToDictionary(x => (int)x, x => x.ToString()), referenceData.LanguageOptions);
        }
    }
}
