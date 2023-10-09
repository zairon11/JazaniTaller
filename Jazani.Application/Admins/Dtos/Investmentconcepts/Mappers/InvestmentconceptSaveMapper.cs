using AutoMapper;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jazani.Application.Admins.Dtos.Investmentconcepts.Mappers
{
    public class InvestmentconceptSaveMapper : Profile
    {
        public InvestmentconceptSaveMapper()
        {
            CreateMap<Investmentconcept, InvestmentconceptSaveDto>().ReverseMap();


        }
    }
}
