using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompanyController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("Alt OK!");
        }
    }
}
