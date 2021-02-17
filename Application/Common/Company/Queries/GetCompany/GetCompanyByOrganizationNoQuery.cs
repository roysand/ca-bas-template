using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Company.Queries.GetCustomers;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Common.Company.Queries.GetCompany
{
    public class GetCompanyByOrganizationNoQuery : IRequest<IEnumerable<Domain.Entities.Company>>
    {
        public string OrganizationNumber { get; set; }

        public GetCompanyByOrganizationNoQuery(string orgNr)
        {
            OrganizationNumber = orgNr;
        }
    }

    public class GetCompanyByOrganizationNoHandler : IRequestHandler<GetCompanyByOrganizationNoQuery, IEnumerable<Domain.Entities.Company>>
    {
        private ICompanyRepository<Domain.Entities.Company> _companyRepository;
        public readonly IMapper _mapper;

        public GetCompanyByOrganizationNoHandler(ICompanyRepository<Domain.Entities.Company> repository, IMapper mapper)
        {
            _companyRepository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Domain.Entities.Company>> Handle(GetCompanyByOrganizationNoQuery request, CancellationToken cancellationToken)
        {
            var result =  _companyRepository.Find(c => c.OrganizationNo == request.OrganizationNumber);

            if (result.Any())
            {
                return result;
            }
            else
            {
                throw new NotFoundException(nameof(Company),request.OrganizationNumber);
            }
        }
    }
}