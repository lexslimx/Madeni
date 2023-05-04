using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public interface IRepaymentService
    {
        RepaymentDto AddRepayment(RepaymentDto RepaymentDto);

        IEnumerable<RepaymentDto> GetRepayments(int? loanId, string userId);

        RepaymentDto GetRepayment(int id);
    }
}