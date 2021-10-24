using Example.Core.Models;
using Example.Core.Models.DTOs;
using Example.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesPersonController : ControllerBase
    {
        private readonly ISalesPersonService SalesPersonService;

        public SalesPersonController(ISalesPersonService salesPersonService)
        {
            SalesPersonService = salesPersonService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<SalesPersonDTO>>> GetAll()
        {
            var salesPeople = await SalesPersonService.GetSalesPeopleAsync();
            var result = salesPeople.Select(x => new SalesPersonDTO(x)).ToList();

            return Ok(result);
        }

        [HttpPost]
        [Route("AssignFree")]
        public async Task<ActionResult<SalesPerson>> AssignFreeSalesPerson(SalesPersonRequest request)
        {
            var salesPersonResponse = new SalesPersonResponse();

            salesPersonResponse.SalesPerson = await SalesPersonService.AssignBestSalePersonAsync(request.CarType, request.LanguageOption);
            salesPersonResponse.SalesPersonFound = salesPersonResponse.SalesPerson != null;

            return Ok(salesPersonResponse);
        }
    }
}
