using AutoMapper;
using Madeni.Server.Models;
using Madeni.Server.Repository;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public class LoanService : ILoanService
    {
        private readonly IRepository<Loan, LoanDto> _repository;
        private readonly IMapper _mapper;
        public LoanService(IRepository<Loan, LoanDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public LoanDto GetLoan(int id)
        {
            var Loan = _repository.GetItem(e => e.Id == id);
            return Loan;
        }

        public IEnumerable<LoanDto> GetLoans(string userId)
        {
            var loans = _repository.GetItems(e => e.UserId == userId).ToList();
            return loans;
        }

        public LoanDto AddLoan(LoanDto LoanDto)
        {
            var Loan = _mapper.Map<Loan>(LoanDto);
            var result = _repository.AddItem(Loan);
            return result;
        }
    }
}
