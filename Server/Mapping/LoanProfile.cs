using AutoMapper;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Mapping
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanDto>().ReverseMap();
        }
    }
}
