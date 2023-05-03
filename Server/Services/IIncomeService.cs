using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public interface IIncomeService
    {
        IncomeDto AddIncome(IncomeDto IncomeDto);
        IEnumerable<IncomeDto> GetIncome(string userId);
        IEnumerable<IncomeDto> GetIncomes(string userId);
    }
}