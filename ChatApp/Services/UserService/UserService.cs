using ChatShared.Models;
using System.Net.Http;

namespace ChatApp.Services;

public class UserService : IUserService
{
  private readonly IHttpService _httpService;
  public UserService(IHttpService httpService)
  {
    _httpService = httpService;
  }

  public async Task<IEnumerable<AppUser>?> GetUsersByNameAsync(string userName)
  {
    IEnumerable<AppUser>? users = await _httpService.GetAsync<IEnumerable<AppUser>?>(
        $"user",
        new Dictionary<string, string>()
        {
          ["userName"] = userName,
        }
      );
    return users;
  }
}
