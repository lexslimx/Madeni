using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public interface ILoanService
    {
        LoanDto AddLoan(LoanDto LoanDto);
        LoanDto GetLoan(int id);
        IEnumerable<LoanDto> GetLoans(string userId);
    }
}