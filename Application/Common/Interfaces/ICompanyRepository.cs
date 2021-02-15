using System.Collections.Generic;
using Application.Common.Company.Queries.GetCustomers;

namespace Application.Common.Interfaces
{
    public interface ICompanyRepository<T> : IRepository<T>
    {
        IEnumerable<CompanyDto> AllWithProjection();

    }
}