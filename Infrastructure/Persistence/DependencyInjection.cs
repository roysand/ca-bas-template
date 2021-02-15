using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IApplicationDbContext,ApplicationDbContext>();
            services.AddTransient<ApplicationDbContext>();
            services.AddTransient<ICompanyRepository<Company>, CompanyRepository>();

            return services;
        }
    }
}
