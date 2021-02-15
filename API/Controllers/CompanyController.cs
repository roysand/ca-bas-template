﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Company.Command.CreateCompany;
using Application.Common.Company.Queries.GetCompany;
using Application.Common.Company.Queries.GetCustomers;
using Application.Common.Interfaces;
using Domain.Entities;
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
        public async Task<ActionResult> GetByOrgNo(string organizationNo)
        {
            var query = new GetCompanyFindQuery(organizationNo);
            var result  = await Mediator.Send(query);
            
            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCompanyCommand query)
        {
            var result = await Mediator.Send(query);

            return CreatedAtAction(nameof(GetByOrgNo), new { organizationNo = result.OrganizationNo }, result);
        }
     }
}
