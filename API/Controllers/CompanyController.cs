using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Controllers
{
    public class CompanyController : ApiControllerBase
    {
        private readonly  ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _context.CompanySet.ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{organizationNo}")]
        public async Task<ActionResult> GetByOrgNo(string organizationNo)
        {
            var result = await _context.CompanySet.Where(w => w.OrganizationNo == organizationNo).ToListAsync();
            if (result.Count == 0)
            {
                return NotFound();
            }
            

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Company company)
        {
            var result = await _context.AddAsync(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByOrgNo), new { organizationNo = result.Entity.OrganizationNo }, result.Entity);
        }
     }
}
