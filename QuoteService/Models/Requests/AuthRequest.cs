using System.ComponentModel.DataAnnotations;

namespace QuoteService.Models.Requests
{
    public class AuthRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
