using AutoMapper;
using Madeni.Server.Models;
using Madeni.Server.Repository;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IRepository<Investment, InvestmentDto> _repository;
        private readonly IMapper _mapper;
        public InvestmentService(IRepository<Investment, InvestmentDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public InvestmentDto AddInvestment(InvestmentDto investmentDto)
        {
            var investment = _mapper.Map<Investment>(investmentDto);
            var result = _repository.AddItem(investment);
            return result;
        }

        public IEnumerable<InvestmentDto> GetInvestments(string userId)
        {
            var investments = _repository.GetItems(e => e.UserId == userId).ToList();
            return investments;
        }
    }
}
