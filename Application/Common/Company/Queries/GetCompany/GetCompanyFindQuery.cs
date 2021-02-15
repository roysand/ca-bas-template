using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Common.Company.Queries.GetCompany
{
    public class GetCompanyFindQuery : IRequest<IEnumerable<Domain.Entities.Company>>
    {
        public  string OrganizationNumber;

        public GetCompanyFindQuery(string orgNr)
        {
            OrganizationNumber = orgNr;
        }
    }

    public class GetCompanyFindQueryHandler : IRequestHandler<GetCompanyFindQuery, IEnumerable<Domain.Entities.Company>>
    {
        private IRepository<Domain.Entities.Company> _companyRepository;

        public GetCompanyFindQueryHandler(IRepository<Domain.Entities.Company> repository)
        {
            _companyRepository = repository;
        }
        public async Task<IEnumerable<Domain.Entities.Company>> Handle(GetCompanyFindQuery request, CancellationToken cancellationToken)
        {
            return _companyRepository.Find(c => c.OrganizationNo == request.OrganizationNumber);
        }
    }
}