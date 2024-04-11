using ChatShared.Models;
using System.Net.Http.Json;

namespace ChatApp.Services.Auth;

public class CustomAuthService : IAuthService
{
  private readonly IHttpClientFactory _httpClientFactory;
  public CustomAuthService(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async Task RegisterAsync(string email, string password)
  {
    HttpClient httpClient = _httpClientFactory.CreateClient("DefaultClient");
    IHttpService httpService = new HttpService(httpClient);

    AppUser_DTOCreate createUser = new() { Email = email, Password = password };

    _ = await httpService.PostAsync("user/register", createUser);
  }

  public async Task LoginAsync(string email, string password)
  {
    HttpClient httpClient = _httpClientFactory.CreateClient("DefaultClient");
    IHttpService httpService = new HttpService(httpClient);

    AppUser_DTOCreate createUser = new() { Email = email, Password = password };

    BearerToken? bt = await httpService.PostAsync<AppUser_DTOCreate, BearerToken>("user/signin", createUser);
    await SecureStorage.Default.SetAsync("BearerToken", bt.AccessToken);
    await SecureStorage.Default.SetAsync("RefreshToken", bt.RefreshToken);
  }

  public Task DeleteAsync()
  {
    throw new NotImplementedException();
  }

  public Task LogoutAsync()
  {
    throw new NotImplementedException();
  }
}
