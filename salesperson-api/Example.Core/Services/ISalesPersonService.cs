using Example.Core.Enums;
using Example.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Core.Services
{
    public interface ISalesPersonService
    {
        public Task<ICollection<SalesPerson>> GetSalesPeopleAsync();

        public Task<SalesPerson> AssignBestSalePersonAsync(CarType carType, LanguageOption languageOption);
    }

}