using ChatShared.Models;
using System.Net.Http;

namespace ChatApp.Services;

public class ContactService : IContactService
{
  private readonly IHttpClientFactory _httpClientFactory;
  public ContactService(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async Task<IEnumerable<AppUser>?> GetUsersByNameAsync(string userName)
  {
    HttpClient httpClient = _httpClientFactory.CreateClient("DefaultClient");
    IHttpService httpService = new HttpService(httpClient);

    IEnumerable<AppUser>? users = await httpService.GetAsync<IEnumerable<AppUser>?>(
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
