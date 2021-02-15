using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.OrganizationNo);
            builder.ToTable("Company", "Aktivitetsfabrikken");

            builder.Property(c => c.OrganizationNo)
                .IsRequired()
                .HasMaxLength(9);
        }
    }
}
