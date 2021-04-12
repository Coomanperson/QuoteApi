using System;
using System.Linq;
using System.Threading.Tasks;
using QuoteService.Interfaces;
using QuoteService.Models.Requests;
using QuoteService.Models.Responses;

namespace QuoteService.Services
{
    public class QuotationService : IQuotationService
    {
        public async Task<QuoteResponse> GetQuote(GetQuoteRequest quoteRequest)
        {
            var ages = quoteRequest.Age.Split(",").Select(int.Parse).ToList();
            var numberOfDays = (quoteRequest.EndDate - quoteRequest.StartDate).Days + 1;
            double total = 0;

            if (ages.Count == 0) throw new ArgumentException("Age cannot be empty.");
            if (ages[0] < 18) throw new ArgumentException("First age in list must be over 18.");
            if (ages.Any(x => x <= 0)) throw new ArgumentException("0 and negative ages are invalid.");
            if (numberOfDays <= 0) throw new ArgumentException("Date selection was invalid.");

            foreach (var age in ages)
            {
                if (age >= 18 && age <= 30)
                    total += (3 * 0.6 * numberOfDays);
                else if (age >= 31 && age <= 40)
                    total += (3 * 0.7 * numberOfDays);
                else if (age >= 41 && age <= 50)
                    total += (3 * 0.8 * numberOfDays);
                else if (age >= 51 && age <= 60)
                    total += (3 * 0.9 * numberOfDays);
                else if (age >= 61 && age <= 70)
                    total += (3 * 1 * numberOfDays);
                else
                    throw new ArgumentException("Ages must be between 18 and 70.");
            }

            return new QuoteResponse
            {
                Total = Math.Round(total, 2).ToString("#.00"),
                CurrencyId = quoteRequest.CurrencyId,
                QuotationId = Guid.NewGuid()
            };
        }
    }
}
