using ChatApp.DataServices;
using ChatApp.Models;
using ChatShared.Models;
using IdentityModel.OidcClient;

namespace ChatApp.Services;

public class UserService
{
  private readonly UserDataService_Local _loc;
  private readonly UserDataService_API _api;
  public UserService(UserDataService_Local loc, UserDataService_API api)
  {
    _loc = loc;
    _api = api;
  }

  public async Task<bool> RegisterAsync(string email, string password)
  {
    bool success = false;
    LoginResult loginResult = null;
    AppUser_DTOCreate createUser = new() { Email = email, Password = password };
    
    success = await _api.CreateUserAsync(createUser);
    if (!success) return false;

    loginResult = await _api.AuthenticateUserAsync(createUser);
    if (loginResult.IsError) return false;

    try
    {
      await SecureStorage.Default.SetAsync("accessToken", loginResult.AccessToken);
    }
    catch (Exception ex)
    {
      return false;
    }

    return true;
  }
}