using AutoMapper;
using Madeni.Server.Models;
using Madeni.Server.Repository;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense, ExpenseDto> _repository;
        private readonly IMapper _mapper;
        public ExpenseService(IRepository<Expense, ExpenseDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ExpenseDto> GetExpense(string userId)
        {
            var Expense = _repository.GetItems(e => e.UserId == userId).ToList();
            return Expense;
        }

        public IEnumerable<ExpenseDto> GetExpenses(string userId)
        {
            var expenses = _repository.GetItems(e => e.UserId == userId).ToList();
            return expenses;
        }

        public ExpenseDto AddExpense(ExpenseDto ExpenseDto)
        {
            var Expense = _mapper.Map<Expense>(ExpenseDto);
            var result = _repository.AddItem(Expense);
            return result;
        }
    }
}
