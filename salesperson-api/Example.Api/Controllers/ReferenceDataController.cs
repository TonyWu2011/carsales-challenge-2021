using Example.Core.Models;
using Example.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Example.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceDataController : ControllerBase
    {
        private readonly IReferenceDataService ReferenceDataService;

        public ReferenceDataController(IReferenceDataService referenceDataService)
        {
            ReferenceDataService = referenceDataService;
        }

        [HttpGet]
        public async Task<ActionResult<ReferenceData>> Get()
        {
            return Ok(await ReferenceDataService.GetReferenceDataAsync());
        }
    }
}
