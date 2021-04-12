using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuoteService.Interfaces;
using QuoteService.Models.Requests;

namespace QuoteService.Controllers
{
    [ApiController]
    [Route("{controller}")]
    [EnableCors("AllowAny")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = _authenticationService.AuthenticateResult(request.UserName, request.Password);

                if (!string.IsNullOrWhiteSpace(token))
                    return Ok(token);
            }
            else 
                return BadRequest();

            return Unauthorized();
        }
    }
}
