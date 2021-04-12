using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuoteService.Interfaces;
using QuoteService.Models.Requests;

namespace QuoteService.Controllers
{
    [Authorize]
    [Route("v1/quotation")]
    [EnableCors("AllowAny")]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [HttpPost]
        public async Task<IActionResult> GetQuote([FromBody]GetQuoteRequest quoteRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _quotationService.GetQuote(quoteRequest);
                    return Ok(response);
                }

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Unknown error encountered.");
            }
        }
    }
}
