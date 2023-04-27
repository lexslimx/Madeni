using AutoMapper;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Mapping
{
    public class GoalProfile : Profile
    {
        public GoalProfile()
        {
            CreateMap<Goal, GoalDto>().ReverseMap();
        }
    }
}
