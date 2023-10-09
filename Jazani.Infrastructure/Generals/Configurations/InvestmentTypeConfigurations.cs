using Jazani.Domain.Generals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Generals.Configurations
{
    public class InvestmentTypeConfigurations : IEntityTypeConfiguration<InvestmentType>
    {
        public void Configure(EntityTypeBuilder<InvestmentType> builder)
        {
            var toDateTime = new ValueConverter<DateTime, DateTimeOffset>(
                dateTime => DateTimeOffset.UtcNow,
                DateTimeOffset => DateTimeOffset.DateTime
                );

            builder.ToTable("investmenttype", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate").HasConversion(toDateTime).HasConversion(toDateTime);
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
