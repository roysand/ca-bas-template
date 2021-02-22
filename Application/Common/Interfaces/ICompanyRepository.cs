using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Behaviours.CommandAndQueries.Company.Queries.GetCompany;

namespace Application.Common.Interfaces
{
    public interface ICompanyRepository<T> : IRepository<T>
    {
        Task<IEnumerable<CompanyDto>> GetAll();
    }
}