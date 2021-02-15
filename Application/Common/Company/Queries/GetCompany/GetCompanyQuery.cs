using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Company.Queries.GetCustomers;
using Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Company.Queries.GetCompany
{
    public class GetCompanyQuery : IRequest<IEnumerable<CompanyDto>>
    {
    }

    public class GetCustomerQueryHandler : IRequestHandler<GetCompanyQuery, IEnumerable<CompanyDto>>
    {

        private readonly ICompanyRepository<Domain.Entities.Company> _companyRepository;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(ICompanyRepository<Domain.Entities.Company> repository, IApplicationDbContext dbContext, IMapper mapper)
        {
            _companyRepository = repository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDto>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            // return await _dbContext.CompanySet
            //     .AsNoTracking()
            //     .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
            //     .ToListAsync(cancellationToken);
            return _companyRepository.AllWithProjection();
        }
    }
}
