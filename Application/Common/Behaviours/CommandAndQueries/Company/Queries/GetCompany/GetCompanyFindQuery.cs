namespace Application.Common.Behaviours.CommandAndQueries.Company.Queries.GetCompany
{
    // public class GetCompanyByOrganizationNoQuery : IRequest<IEnumerable<Domain.Entities.Company>>
    // {
    //     public  string OrganizationNumber;
    //
    //     public GetCompanyByOrganizationNoQuery(string orgNr)
    //     {
    //         OrganizationNumber = orgNr;
    //     }
    // }
    //
    // public class GetCompanyByOrganizationNoHandler : IRequestHandler<GetCompanyByOrganizationNoQuery, IEnumerable<Domain.Entities.Company>>
    // {
    //     private ICompanyRepository<Domain.Entities.Company> _companyRepository;
    //
    //     public GetCompanyByOrganizationNoHandler(ICompanyRepository<Domain.Entities.Company> repository)
    //     {
    //         _companyRepository = repository;
    //     }
    //     public async Task<IEnumerable<Domain.Entities.Company>> Handle(GetCompanyByOrganizationNoQuery request, CancellationToken cancellationToken)
    //     {
    //         var result =  _companyRepository.Find(c => c.OrganizationNo == request.OrganizationNumber);
    //
    //         if (result.Any())
    //         {
    //             return result;
    //         }
    //         else
    //         {
    //             throw new NotFoundException(nameof(Company), request.OrganizationNumber);
    //         }
    //     }
    // }
}