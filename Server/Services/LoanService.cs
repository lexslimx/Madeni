using AutoMapper;
using Madeni.Server.Models;
using Madeni.Server.Repository;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public class LoanService : ILoanService
    {
        private readonly IRepository<Loan, LoanDto> _repository;
        private readonly IRepository<Repayment, RepaymentDto> _repaymentsRepository;
        private readonly IMapper _mapper;
        public LoanService(IRepository<Loan, LoanDto> repository, IMapper mapper, IRepository<Repayment, RepaymentDto> repaymentsRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _repaymentsRepository = repaymentsRepository;
        }

        public LoanDto GetItem(int id)
        {
            var Loan = _repository.GetItem(e => e.Id == id);
            var repayments = _repaymentsRepository.GetItems(e => e.LoanId == id);
            Loan.Repayments = repayments.ToList();
            return Loan;
        }

        public IEnumerable<LoanDto> GetItems(string userId)
        {
            var loans = _repository.GetItems(e => e.UserId == userId).ToList();
            return loans;
        }

        public LoanDto AddItem(LoanDto LoanDto)
        {
            var Loan = _mapper.Map<Loan>(LoanDto);
            var result = _repository.AddItem(Loan);
            return result;
        }
    }
}
