using ChatShared.Models;
using System.Net.Http;

namespace ChatApp.Services;

public class ContactService : IContactService
{
  private readonly IHttpService _httpService;
  public ContactService(IHttpService httpService)
  {
    _httpService = httpService;
  }

  public async Task<IEnumerable<AppUser>?> GetUsersByNameAsync(string userName)
  {
    IEnumerable<AppUser>? users = await _httpService.GetAsync<IEnumerable<AppUser>?>(
        $"users",
        new Dictionary<string, string>()
        {
          ["name"] = userName,
        }
      );
    return users;
  }

  public async Task<bool> AddUserToContacts(string userId)
  {
    /*    HttpClient httpClient = _httpClientFactory.CreateClient("AuthedClient");
        IHttpService httpService = new HttpService(httpClient);

        return await httpService.PostAsync($"users/{userId}");*/
    return false;
  }

}
