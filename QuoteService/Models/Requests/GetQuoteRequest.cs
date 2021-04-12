using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuoteService.Models.Requests
{
    public class GetQuoteRequest
    {
        [Required]
        public string Age { get; set; }

        [Required]
        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        [Required]
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [Required]
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }
    }
}
