using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Company.Queries.GetCustomers;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Common.Company.Command.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Domain.Entities.Company>
    {
        public string OrganizationNo { get; set; }
        public string Profile { get; set; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Domain.Entities.Company>
    {
        private readonly ICompanyRepository<Domain.Entities.Company> _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository<Domain.Entities.Company> repository)
        {
            _companyRepository = repository;
        }

        public async Task<Domain.Entities.Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Domain.Entities.Company()
            {
                OrganizationNo = request.OrganizationNo,
                Profile = request.Profile
            };

            company = _companyRepository.Add(company);
            _companyRepository.SaveChanges();

            return company;
        }
    }
}
