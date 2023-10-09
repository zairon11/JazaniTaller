using AutoMapper;
using Jazani.Application.Admins.Dtos.Investmentconcepts;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class InvestmentconceptService : IInvestmentconceptService
    {
        private readonly IInvestmentconceptRepository _investmentconceptRepository;
        private readonly IMapper _mapper;

        public InvestmentconceptService(IInvestmentconceptRepository investmentconceptRepository, IMapper mapper)
        {
            _investmentconceptRepository = investmentconceptRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<InvestmentconceptDto>> FindAllAsync()
        {
            IReadOnlyList<Investmentconcept> investmentconcepts = await _investmentconceptRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentconceptDto>>(investmentconcepts);

        }

        public async Task<InvestmentconceptDto?> FindByIdAsync(int id)
        {
            Investmentconcept? investmentconcept = await _investmentconceptRepository.FindByIdAsync(id);
            return _mapper.Map<InvestmentconceptDto>(investmentconcept);
        }

        //--
        public async Task<InvestmentconceptDto> CreateAsync(InvestmentconceptSaveDto investmentconceptSaveDto)
        {
            Investmentconcept investmentconcept = _mapper.Map<Investmentconcept>(investmentconceptSaveDto);
            investmentconcept.RegistrationDate = DateTime.Now;
            investmentconcept.State = true;
            Investmentconcept personaSaved = await _investmentconceptRepository.SaveAsync(investmentconcept);

            return _mapper.Map<InvestmentconceptDto>(personaSaved);
        }

        public async  Task<InvestmentconceptDto> DisabledAsync(int id)
        {
            Investmentconcept investmentconcept = await _investmentconceptRepository.FindByIdAsync(id);
            investmentconcept.State = false;
            Investmentconcept investmentconceptSaved = await _investmentconceptRepository.SaveAsync(investmentconcept);
            return _mapper.Map<InvestmentconceptDto>(investmentconceptSaved);
        }

        public async Task<InvestmentconceptDto> EditAsync(int id, InvestmentconceptSaveDto investmentconceptSaveDto)
        {
            Investmentconcept investmentconcept = await _investmentconceptRepository.FindByIdAsync(id);
            _mapper.Map<InvestmentconceptSaveDto, Investmentconcept>(investmentconceptSaveDto, investmentconcept);
            Investmentconcept investmentconceptSaved = await _investmentconceptRepository.SaveAsync(investmentconcept);

            return _mapper.Map<InvestmentconceptDto>(investmentconceptSaved);
        }

    }
}
