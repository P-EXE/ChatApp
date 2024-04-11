namespace ChatApp.Services.Auth;

internal interface IAuthService
{
  Task RegisterAsync(string email, string password);
  Task LoginAsync(string email, string password);
  Task LogoutAsync();
  Task DeleteAsync();
}
