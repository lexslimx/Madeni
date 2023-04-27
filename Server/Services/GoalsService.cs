using AutoMapper;
using IdentityModel;
using Madeni.Server.Data;
using Madeni.Server.Models;
using Madeni.Server.Repository;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public class GoalsService : IGoalsService
    {
        private readonly IRepository<Goal, GoalDto> _repository;
        private readonly IMapper _mapper;
        public GoalsService(IRepository<Goal, GoalDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<GoalDto> GetGoals(string userId)
        {
            var goals = _repository.GetItems(e => e.UserId == userId).ToList();
            return goals;
        }

        public GoalDto AddGoal(GoalDto goalDto)
        {
            var goal = _mapper.Map<Goal>(goalDto);
            var result = _repository.AddItem(goal);
            return result;
        }
    }
}
