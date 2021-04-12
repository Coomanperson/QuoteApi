using System;
using System.Text.Json.Serialization;

namespace QuoteService.Models.Responses
{
    public class QuoteResponse
    {
        public string Total { get; set; }

        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }
        
        [JsonPropertyName("quotation_id")]
        public Guid QuotationId { get; set; }
    }
}
