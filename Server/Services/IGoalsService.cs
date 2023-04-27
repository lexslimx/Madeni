using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public interface IGoalsService
    {
        GoalDto AddGoal(GoalDto goalDto);
        IEnumerable<GoalDto> GetGoals(string userId);
    }
}