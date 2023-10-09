using AutoMapper;
using Jazani.Application.Generals.Dtos.InvestmentTypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class InvestmentTypeService : IInvestmentTypeService
    {
        private readonly IInvestmentTypeRepository _investmentTypeRepository;
        private readonly IMapper _mapper;

        public InvestmentTypeService(IInvestmentTypeRepository notificationTypeRepository, IMapper mapper)
        {
            _investmentTypeRepository = notificationTypeRepository;
            _mapper = mapper;
        }

        public async  Task<InvestmentTypeDto> CreateAsync(InvestmentTypeSaveDto saveDto)
        {
            InvestmentType investmentType = _mapper.Map<InvestmentType>(saveDto);
            investmentType.RegistrationDate = DateTime.Now;
            investmentType.State = true;
            await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<InvestmentTypeDto> DisabledAsync(int id)
        {
            InvestmentType investmentType = await _investmentTypeRepository.FindByIdAsync(id);
            investmentType.State = false;
            await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async  Task<InvestmentTypeDto> EditAsync(int id, InvestmentTypeSaveDto saveDto)
        {
            InvestmentType investmentType = await _investmentTypeRepository.FindByIdAsync(id);
            _mapper.Map<InvestmentTypeSaveDto, InvestmentType>(saveDto, investmentType);
            await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async  Task<IReadOnlyList<InvestmentTypeDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentType> investmentTypes = await _investmentTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentTypeDto>>(investmentTypes);
        }

        public async Task<InvestmentTypeDto?> FindByIdAsync(int id)
        {
            InvestmentType notificationType = await _investmentTypeRepository.FindByIdAsync(id);


            return _mapper.Map<InvestmentTypeDto>(notificationType);
        }
    }
}
