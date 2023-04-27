using Madeni.Server.Data;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public class GoalsService
    {
        private readonly ApplicationDbContext _context;
        public GoalsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GoalDto> GetGoals(string userId)
        {
            var goals = _context.Goals.Where(e => e.UserId == userId).ToList();
            List<GoalDto> results = new List<GoalDto>();
            foreach (var goal in goals)
            {
                results.Add(new GoalDto
                {
                    Id = goal.Id,
                    Description = goal.Description, 
                    Name = goal.Name,
                    StartDate = goal.StartDate,
                    TargetDate = goal.TargetDate
                });
            }
            return results;
        }

        public GoalDto AddGoal(GoalDto goalDto) {
            var goal = new Goal
            {
                Name = goalDto.Name,
                Description = goalDto.Description,
                StartDate = goalDto.StartDate,
                TargetDate = goalDto.TargetDate
            };

            _context.Goals.Add(goal);
            _context.SaveChanges();

            //Using generic repository should take care of the Id not being returned here
            return goalDto;
        }
    }
}
