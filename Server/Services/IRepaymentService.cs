using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public interface IRepaymentService
    {
        RepaymentDto AddRepayment(RepaymentDto RepaymentDto);
        IEnumerable<RepaymentDto> GetRepayment(string userId);
    }
}