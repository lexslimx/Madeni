using AutoMapper;
using Madeni.Server.Models;
using Madeni.Server.Repository;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Services
{
    public interface IInvestmentService
    {
        InvestmentDto AddInvestment(InvestmentDto goalDto);
        IEnumerable<InvestmentDto> GetInvestments(string userId);
    }
}