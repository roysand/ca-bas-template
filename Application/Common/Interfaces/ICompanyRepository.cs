using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Company.Queries.GetCustomers;

namespace Application.Common.Interfaces
{
    public interface ICompanyRepository<T> : IRepository<T>
    {
        Task<IEnumerable<CompanyDto>> AllWithProjection();
    }
}