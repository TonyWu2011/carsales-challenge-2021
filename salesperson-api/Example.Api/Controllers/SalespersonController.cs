using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Example.Core.Models;
using Example.Core.Services;

namespace Example.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesPersonController : ControllerBase
    {
        private readonly ISalesPersonService salesPersonService;

        public SalesPersonController(ISalesPersonService salesPersonService)
        {
            this.salesPersonService = salesPersonService;
        }

        [HttpGet]
        public IEnumerable<SalesPerson> List()
        {
            return salesPersonService.List();
        }
    }
}
