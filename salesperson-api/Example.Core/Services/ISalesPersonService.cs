using Example.Core.Models;
using System.Threading.Tasks;

namespace Example.Core.Services
{
    public interface ISalesPersonService
    {
        public Task<SalesPerson> AssignBestSalePersonAsync();
    }

}