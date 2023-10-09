using Jazani.Application.Admins.Dtos.Investmentconcepts;
using Jazani.Application.Generals.Dtos.InvestmentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services
{
    public interface IInvestmentTypeService
    {
        Task<IReadOnlyList<InvestmentTypeDto>> FindAllAsync();
        Task<InvestmentTypeDto?> FindByIdAsync(int id);
        Task<InvestmentTypeDto> CreateAsync(InvestmentTypeSaveDto investmentTypeSaveDto);
        Task<InvestmentTypeDto> EditAsync(int id, InvestmentTypeSaveDto investmentTypeSaveDto);
        Task<InvestmentTypeDto> DisabledAsync(int id);
    }
}
