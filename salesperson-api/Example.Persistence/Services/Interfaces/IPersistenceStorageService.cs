using Example.Persistence.Models;
using System.Threading.Tasks;

namespace Example.Persistence.Services
{
    public interface IPersistenceStorageService
    {
        public Task<MemoryStorage> GetDataFromPersistenceAsync();
    }
}
