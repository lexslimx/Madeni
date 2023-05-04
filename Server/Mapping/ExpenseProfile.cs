using AutoMapper;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Mapping
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseDto>().ReverseMap();
        }
    }
}
