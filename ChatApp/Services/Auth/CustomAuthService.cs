using ChatShared.Models;
using System.Diagnostics;

namespace ChatApp.Services.Auth;

public class CustomAuthService : IAuthService
{
  private readonly IHttpClientFactory _httpClientFactory;
  public CustomAuthService(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async Task<bool> RegisterAsync(string email, string password)
  {
    HttpClient httpClient = _httpClientFactory.CreateClient("DefaultClient");
    IHttpService httpService = new HttpService(httpClient);

    AppUser_DTOCreate createUser = new() { Email = email, Password = password };

    bool result = await httpService.PostAsync("user/register", createUser);
    return result;
  }

  public async Task<bool> LoginAsync(string email, string password)
  {
    HttpClient httpClient = _httpClientFactory.CreateClient("DefaultClient");
    IHttpService httpService = new HttpService(httpClient);

    AppUser_DTOCreate createUser = new() { Email = email, Password = password };

    BearerToken? bt = await httpService.PostAsync<AppUser_DTOCreate, BearerToken>("user/login", createUser);
    if (bt != null)
    {
      Debug.WriteLine($"==Success==> {nameof(LoginAsync)} : Got {nameof(BearerToken)}");

      Constants.BearerToken = bt;
      await SecureStorage.Default.SetAsync("AccessToken", bt.AccessToken);
      await SecureStorage.Default.SetAsync("RefreshToken", bt.RefreshToken);
      return true;
    }
    return false;
  }

  public async Task<bool> DeleteAsync()
  {
    throw new NotImplementedException();
    return false;
  }

  public async Task<bool> LogoutAsync()
  {
    throw new NotImplementedException();
    return false;
  }

  public async Task<bool> CheckUserLoginStateAsync()
  {
    string? bt = await SecureStorage.Default.GetAsync("AccessToken");
    if (bt != null) return true;
    return false;
  }
}
