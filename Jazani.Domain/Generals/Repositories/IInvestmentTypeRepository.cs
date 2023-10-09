using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Generals.Repositories
{
    public interface IInvestmentTypeRepository
    {
        
        Task<IReadOnlyList<InvestmentType>> FindAllAsync();
        Task<InvestmentType?> FindByIdAsync(int id);
        Task<InvestmentType> SaveAsync(InvestmentType investmentType);
         
    }
}
