using AutoMapper;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Mapping
{
    public class RepaymentProfile : Profile
    {
        public RepaymentProfile()
        {
            CreateMap<Repayment, RepaymentDto>().ReverseMap().ForMember(m=>m.Loan, opt => opt.Ignore());
        }
    }
}
