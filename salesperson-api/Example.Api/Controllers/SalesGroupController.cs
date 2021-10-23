using Example.Core.Models;
using Example.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesGroupController : ControllerBase
    {
        private readonly ISalesGroupService SalesGroupService;

        public SalesGroupController(ISalesGroupService salesGroupService)
        {
            SalesGroupService = salesGroupService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<SalesGroup>>> GetAll()
        {
            return Ok(await SalesGroupService.GetSalesGroupsAsync());
        }
    }
}
