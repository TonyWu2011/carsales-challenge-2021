using Example.Core.Models;
using System.Threading.Tasks;

namespace Example.Core.Services
{
    public interface IReferenceDataService
    {
        public Task<ReferenceData> GetReferenceDataAsync();
    }
}
