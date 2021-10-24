using Example.Core.Services.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Example.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService StorageService;

        public StorageController(IStorageService storageService)
        {
            StorageService = storageService;
        }

        [HttpPost]
        public async Task<ActionResult> Reset()
        {
            await StorageService.ResetStorageAsync();

            return Ok();
        }
    }
}
