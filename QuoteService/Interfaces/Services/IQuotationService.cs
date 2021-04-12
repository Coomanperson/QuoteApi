using System.Threading.Tasks;
using QuoteService.Models.Requests;
using QuoteService.Models.Responses;

namespace QuoteService.Interfaces
{
    public interface IQuotationService
    {
        Task<QuoteResponse> GetQuote(GetQuoteRequest quoteRequest);
    }
}
