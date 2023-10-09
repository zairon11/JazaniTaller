using Jazani.Domain.Admins.Models;
using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Admins.Configurations;
using Jazani.Infrastructure.Generals.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region "Dbset"

        public DbSet<Investmentconcept> Investmentconcepts { get; set; }
        public DbSet<InvestmentType> investmentTypes { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new InvestmentconceptConfiguration());
            modelBuilder.ApplyConfiguration(new InvestmentTypeConfigurations());
        }
    }
}
