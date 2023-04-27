using Madeni.Server.Services;
using Madeni.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalsService _goalsService;
        public GoalsController(IGoalsService goalsService)
        {
            _goalsService = goalsService;

        }
        // GET: api/<GoalsController>
        [HttpGet]
        public IEnumerable<GoalDto> Get(string userId)
        {
            return _goalsService.GetGoals(userId);
        }

        // GET api/<GoalsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<GoalsController>
        [HttpPost]
        public GoalDto Post([FromBody] GoalDto goalDto)
        {
            return _goalsService.AddGoal(goalDto);            
        }

        // PUT api/<GoalsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<GoalsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
