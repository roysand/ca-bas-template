using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompanyController : ApiControllerBase
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyController(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result =  _companyRepository.All();
            return Ok(result);
        }

        [HttpGet]
        [Route("{organizationNo}")]
        public async Task<ActionResult> GetByOrgNo(string organizationNo)
        {
            var result = _companyRepository.Find(w => w.OrganizationNo == organizationNo);
            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Company company)
        {
            var result = _companyRepository.Add(company);
            // await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByOrgNo), new { organizationNo = result.OrganizationNo }, result);
        }
     }
}
