using AutoMapper;
using Madeni.Server.Models;
using Madeni.Server.Repository;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public class RepaymentService : IRepaymentService
    {
        private readonly IRepository<Repayment, RepaymentDto> _repository;
        private readonly IMapper _mapper;
        public RepaymentService(IRepository<Repayment, RepaymentDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public RepaymentDto GetRepayment(int id)
        {
            var Repayment = _repository.GetItem(e => e.Id == id);
            return Repayment;
        }

        public IEnumerable<RepaymentDto> GetRepayments(int? loanId, string userId)
        {
            var repayments = _repository.GetItems(e => e.UserId == userId && e.LoanId == loanId).ToList();
            return repayments;
        }

        public RepaymentDto AddRepayment(RepaymentDto RepaymentDto)
        {
            var Repayment = _mapper.Map<Repayment>(RepaymentDto);
            var result = _repository.AddItem(Repayment);
            return result;
        }
    }
}
