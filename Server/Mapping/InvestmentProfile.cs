using AutoMapper;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Mapping
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, InvestmentDto>().ReverseMap();
        }
    }
}
