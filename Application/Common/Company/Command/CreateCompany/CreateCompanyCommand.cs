using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Company.Queries.GetCustomers;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using MediatR;

namespace Application.Common.Company.Command.CreateCompany
{
    public class CreateCompanyCommand : IMapFrom<Domain.Entities.Company>, IRequest<CompanyDto>
    {
        public string OrganizationNo { get; set; }
        public string Profile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCompanyCommand, Domain.Entities.Company>();
        }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
    {
        private readonly ICompanyRepository<Domain.Entities.Company> _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyRepository<Domain.Entities.Company> repository, IMapper mapper)
        {
            _companyRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            // Does Company exists
            var company = await _companyRepository.Find(c => c.OrganizationNo == request.OrganizationNo);
            if (!company.Any())
            {
                var company2Insert = _mapper.Map<Domain.Entities.Company>(request); 

                company2Insert = _companyRepository.Add(company2Insert);
                await _companyRepository.SaveChanges();
                
                return _mapper.Map<CompanyDto>(company2Insert);
            }

            throw new NotFoundException(nameof(Company),request.OrganizationNo);
        }
    }
}
