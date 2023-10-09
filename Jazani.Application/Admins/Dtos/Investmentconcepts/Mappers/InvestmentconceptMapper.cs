using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Investmentconcepts.Mappers
{
    public class InvestmentconceptMapper :Profile
    {
        public InvestmentconceptMapper()
        {
            CreateMap<Investmentconcept, InvestmentconceptDto>();

        }
    }
}
