using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Common.Company.Command.CreateCompany;
using Application.Common.Company.Queries.GetCompany;
using Application.Common.Company.Queries.GetCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompanyController : ApiControllerBase
    {
        public CompanyController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
        {
            var query = new GetCompanyQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{organizationNo}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetByOrgNo(string organizationNo)
        {
            var query = new GetCompanyByOrganizationNoQuery(organizationNo);
            var result  = await Mediator.Send(query);
            
            return Ok(result);
        }
        
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CreateCompanyCommand query)
        {
            var result = await Mediator.Send(query);

            return CreatedAtAction(nameof(GetByOrgNo), new { organizationNo = result.OrganizationNo }, result);
        }
     }
}
