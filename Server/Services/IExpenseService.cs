using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public interface IExpenseService
    {
        ExpenseDto AddExpense(ExpenseDto ExpenseDto);
        IEnumerable<ExpenseDto> GetExpense(string userId);
        IEnumerable<ExpenseDto> GetExpenses(string userId);
    }
}