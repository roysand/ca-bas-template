using Application.Common.Mappings;

namespace Application.Common.Behaviours.CommandAndQueries.Company.Queries.GetCompany
{
    public class CompanyDto : IMapFrom<Domain.Entities.Company>
    {
        public string OrganizationNo { get; set; }
        public string Profile { get; set; }
    }
}
