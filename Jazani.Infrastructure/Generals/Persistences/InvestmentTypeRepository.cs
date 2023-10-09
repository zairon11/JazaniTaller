using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class InvestmentTypeRepository : IInvestmentconceptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvestmentTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<InvestmentType>> FindAllAsync()
        {
            return await _dbContext.investmentTypes.AsNoTracking().ToListAsync();
        }

        public async Task<InvestmentType?> FindByIdAsync(int id)
        {
            return await _dbContext.investmentTypes.FindAsync(id);
        }

        public async Task<InvestmentType> SaveAsync(InvestmentType investmentType)
        {
            EntityState state = _dbContext.Entry(investmentType).State;

            _ = state switch
            {
                EntityState.Detached => _dbContext.investmentTypes.Add(investmentType),
                EntityState.Modified => _dbContext.investmentTypes.Update(investmentType)

            } ; 

            await _dbContext.SaveChangesAsync();

            return investmentType;

        }
    }
}
