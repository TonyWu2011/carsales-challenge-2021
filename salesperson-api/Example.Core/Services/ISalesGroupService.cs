using Example.Core.Enums;
using Example.Core.Models;
using System.Threading.Tasks;

namespace Example.Core.Services
{
    public interface ISalesGroupService
    {
        public Task<SalesGroup> GetBestSalesGroupWithAvailabilityAsync(LanguageOption languageOption, CarType carType);
    }
}
