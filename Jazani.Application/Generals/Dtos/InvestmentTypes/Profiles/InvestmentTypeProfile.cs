using AutoMapper;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.InvestmentTypes.Profiles
{
    public class InvestmentTypeProfile : Profile
    {
        public InvestmentTypeProfile()
        {
            CreateMap<InvestmentType, InvestmentTypeDto>();
            CreateMap<InvestmentType, InvestmentTypeDto>().ReverseMap();
        }
    }
}
