using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Common.Behaviours.CommandAndQueries.Company.Queries.GetCompany
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
            return await _companyRepository.GetAll();
        }
    }
}
