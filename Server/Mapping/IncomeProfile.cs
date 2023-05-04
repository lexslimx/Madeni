using AutoMapper;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Mapping
{
    public class IncomeProfile : Profile
    {
        public IncomeProfile()
        {
            CreateMap<Income, IncomeDto>().ReverseMap();
        }
    }
}
