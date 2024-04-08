using ChatShared.Models;
using System.Text;
using System.Text.Json;

namespace ChatApp.DataServices;

internal class UserDataService_API : IUserDataService
{
  private readonly HttpClient _httpClient;
  private readonly JsonSerializerOptions _jsonSerializerOptions;
  public UserDataService_API()
  {
    _httpClient = new HttpClient();

    _jsonSerializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
  }

  public async Task<AppUser?> CreateUserAsync(AppUser_DTOCreate createUser)
  {
    string json = JsonSerializer.Serialize(createUser, _jsonSerializerOptions);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await _httpClient.PostAsync($"{DataServiceSettings.Address}/user/register", content);
    string responseContent = await response.Content.ReadAsStringAsync();
    AppUser? user = JsonSerializer.Deserialize<AppUser?>(responseContent, _jsonSerializerOptions);
    return user;
  }

  public async Task<BearerToken?> ValidateUserAsync(AppUser_DTOCreate createUser)
  {
    string? json = JsonSerializer.Serialize(createUser, _jsonSerializerOptions);
    StringContent? content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage? response = await _httpClient.PostAsync($"{DataServiceSettings.Address}/user/login", content);
    string? responseContent = await response.Content.ReadAsStringAsync();
    BearerToken? bearerToken = JsonSerializer.Deserialize<BearerToken?>(responseContent, _jsonSerializerOptions);
    return bearerToken;
  }

  public async Task<BearerToken?> RenewBearerTokenAsync(BearerToken bearerTokenOld)
  {
    string? json = JsonSerializer.Serialize(bearerTokenOld.RefreshToken, _jsonSerializerOptions);
    StringContent? content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage? response = await _httpClient.PostAsync($"{DataServiceSettings.Address}/user/refresh", content);
    string? responseContent = await response.Content.ReadAsStringAsync();
    BearerToken? bearerToken = JsonSerializer.Deserialize<BearerToken?>(responseContent, _jsonSerializerOptions);
    return bearerToken;
  }

  public async Task<AppUser?> GetUserByIdAsync(Guid userId)
  {
    HttpResponseMessage response = await _httpClient.GetAsync($"{DataServiceSettings.Address}/users/{userId}");
    string responseContent = await response.Content.ReadAsStringAsync();
    AppUser? user = JsonSerializer.Deserialize<AppUser?>(responseContent, _jsonSerializerOptions);
    return user;
  }
}
