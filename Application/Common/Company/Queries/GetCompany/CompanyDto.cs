using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;

namespace Application.Common.Company.Queries.GetCustomers
{
    public class CompanyDto : IMapFrom<Domain.Entities.Company>
    {
        public string OrganizationNo { get; set; }
        public string Profile { get; set; }
    }
}
