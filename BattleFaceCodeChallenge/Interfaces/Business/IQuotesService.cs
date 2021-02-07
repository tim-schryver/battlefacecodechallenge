using BattleFaceCodeChallenge.Models;
using System.Threading.Tasks;

namespace BattleFaceCodeChallenge
{
    public interface IQuotesService
    {
        Task<QuoteResponse> CalculateQuote(QuoteRequest quote);
    }
}