using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Common.Company.Command.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Domain.Entities.Company>
    {
        public Domain.Entities.Company Company;
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Domain.Entities.Company>
    {
        private readonly IRepository<Domain.Entities.Company> _companyRepository;

        public CreateCompanyCommandHandler(IRepository<Domain.Entities.Company> repository)
        {
            _companyRepository = repository;
        }

        public async Task<Domain.Entities.Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Domain.Entities.Company()
            {
                OrganizationNo = request.Company.OrganizationNo,
                Profile = request.Company.Profile
            };

            company = _companyRepository.Add(company);
            _companyRepository.SaveChanges();

            return company;
        }
    }
}
