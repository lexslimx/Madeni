using AutoMapper;
using Madeni.Server.Models;
using Madeni.Server.Repository;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IRepository<Income, IncomeDto> _repository;
        private readonly IMapper _mapper;
        public IncomeService(IRepository<Income, IncomeDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<IncomeDto> GetIncome(string userId)
        {
            var Income = _repository.GetItems(e => e.UserId == userId).ToList();
            return Income;
        }

        public IEnumerable<IncomeDto> GetIncomes(string userId)
        {
            var Incomes = _repository.GetItems(e => e.UserId == userId).ToList();
            return Incomes;
        }

        public IncomeDto AddIncome(IncomeDto IncomeDto)
        {
            var Income = _mapper.Map<Income>(IncomeDto);
            var result = _repository.AddItem(Income);
            return result;
        }
    }
}
