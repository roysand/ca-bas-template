using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Common.Company.Queries.GetCompany
{
    public class GetCompanyQuery : IRequest<IEnumerable<Domain.Entities.Company>>
    {
    }

    public class GetCustomerQueryHandler : IRequestHandler<GetCompanyQuery, IEnumerable<Domain.Entities.Company>>
    {

        private readonly IRepository<Domain.Entities.Company> _companyRepository;

        public GetCustomerQueryHandler(IRepository<Domain.Entities.Company> repository)
        {
            _companyRepository = repository;
        }
        public async Task<IEnumerable<Domain.Entities.Company>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            return _companyRepository.All();
        }
    }
}
