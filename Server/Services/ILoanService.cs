using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public interface ILoanService
    {
        LoanDto AddItem(LoanDto LoanDto);
        LoanDto GetItem(int id);
        IEnumerable<LoanDto> GetItems(string userId);
    }
}