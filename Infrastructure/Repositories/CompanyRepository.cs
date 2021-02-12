using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}