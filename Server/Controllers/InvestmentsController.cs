using Madeni.Server.Services;
using Madeni.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;
        public InvestmentsController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }
        // GET: api/<InvestmentsController>
        [HttpGet]
        public IEnumerable<InvestmentDto> Get(string userId)
        {
            return _investmentService.GetInvestments(userId);
        }

        // GET api/<InvestmentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<InvestmentsController>
        [HttpPost]
        public InvestmentDto Post([FromBody] InvestmentDto investmentDto)
        {
            var result = _investmentService.AddInvestment(investmentDto);
            return result;
        }

        // PUT api/<InvestmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<InvestmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
