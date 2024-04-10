using ChatShared.Models;
using IdentityModel.OidcClient;

namespace ChatApp.DataServices;

public class UserDataService_API
{
  private readonly HTTPDataService _httpDataService;
  private readonly OidcClient _oidcClient;
  private readonly string _baseAddress;
  public UserDataService_API(HTTPDataService httpDataService, OidcClient oidcClient)
  {
    _httpDataService = httpDataService;
    _baseAddress = $"https://localhost:7014/api";
    _oidcClient = oidcClient;
  }

  public async Task<bool> CreateUserAsync(AppUser_DTOCreate createUser)
  {
    return await _httpDataService.HTTPPost<AppUser_DTOCreate, bool>(_baseAddress + "/user/register", createUser);
  }
  public async Task<LoginResult> AuthenticateUserAsync(AppUser_DTOCreate createUser)
  {
    return await _oidcClient.LoginAsync();
  }
}
