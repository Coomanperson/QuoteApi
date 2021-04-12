namespace QuoteService.Interfaces
{
    public interface IAuthenticationService
    {
        string AuthenticateResult(string username, string password);
    }
}
