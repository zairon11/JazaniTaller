using Microsoft.AspNetCore.Mvc;

using Jazani.Infrastructure.Admins.Persistences;
using Jazani.Domain.Admins.Repositories;
using Jazani.Application.Admins.Services;
using Jazani.Domain.Admins.Models;
using Jazani.Application.Admins.Services.Implementations;
using Jazani.Application.Admins.Dtos.Investmentconcepts;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentconceptController : ControllerBase
    {

        private readonly IInvestmentconceptService _investmentconceptService;


        public InvestmentconceptController(IInvestmentconceptService investmentconceptService)
        {
            _investmentconceptService = investmentconceptService;
        }

        // GET: api/<PersonaController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentconceptDto>> Get()
        {
            return await _investmentconceptService.FindAllAsync();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public async Task<InvestmentconceptDto> Get(int id)
        {
            return await _investmentconceptService.FindByIdAsync(id);
        }

        // POST api/<PersonaController>
        [HttpPost]
        public async Task<InvestmentconceptDto> Post([FromBody] InvestmentconceptSaveDto investmentconceptSaveDto)
        {
            return await _investmentconceptService.CreateAsync(investmentconceptSaveDto);
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public async Task<InvestmentconceptDto> Put(int id, [FromBody] InvestmentconceptSaveDto investmentconceptSaveDto)
        {
            return await _investmentconceptService.EditAsync(id, investmentconceptSaveDto);
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentconceptDto> Delete(int id)
        {
            return await _investmentconceptService.DisabledAsync(id);
        }
    }
}
