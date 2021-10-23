using Example.Core.Enums;
using Example.Core.Models;
using Example.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Infrastructure.Services
{
    public class ReferenceDataService : IReferenceDataService
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ReferenceData> GetReferenceDataAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var referenceData = new ReferenceData();

            referenceData.CarTypes = Enum.GetValues<CarType>().ToDictionary(x => (int)x, x=> x.ToString());
            referenceData.LanguageOptions = Enum.GetValues<LanguageOption>().ToDictionary(x => (int)x, x => x.ToString());

            return referenceData;
        }
    }
}
