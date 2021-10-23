using Example.Core.Models.Persistence;
using System.Threading.Tasks;

namespace Example.Core.Services.Persistence
{
    public interface IPersistenceStorageService
    {
        public Task<MemoryStorage> GetDataFromPersistenceAsync();
    }
}
