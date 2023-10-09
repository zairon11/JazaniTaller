using Jazani.Domain.Admins.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;
using Jazani.Infrastructure.Generals.Persistences;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class InvestmentconceptRepository : IInvestmentconceptRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InvestmentconceptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<IReadOnlyList<Investmentconcept>> FindAllAsync()
        {
            return await _dbContext.Investmentconcepts.ToListAsync();
        }

        public async Task<Investmentconcept?> FindByIdAsync(int id)
        {
            return await _dbContext.Investmentconcepts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Investmentconcept> SaveAsync(Investmentconcept investmentconcept)
        {
            EntityState state = _dbContext.Entry(investmentconcept).State;

            _ = state switch
            {
                EntityState.Detached => _dbContext.Investmentconcepts.Add(investmentconcept),
                EntityState.Modified => _dbContext.Investmentconcepts.Update(investmentconcept),
            };

            await _dbContext.SaveChangesAsync();

            return investmentconcept;
        }
    }
}
