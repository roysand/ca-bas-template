using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Behaviours.CommandAndQueries.Company.Queries.GetCompany;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository<Company>
    {
        private readonly IMapper _mapper;

        public CompanyRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            return await _context.CompanySet
                .AsNoTracking()
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}