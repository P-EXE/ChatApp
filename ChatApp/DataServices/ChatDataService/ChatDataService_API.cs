using ChatShared.Models;
using System.Text;
using System.Text.Json;

namespace ChatApp.DataServices;

public class ChatDataService_API : IChatDataService
{
  private readonly HttpClient _httpClient;
  private readonly JsonSerializerOptions _jsonSerializerOptions;

  public ChatDataService_API()
  {
    _httpClient = new HttpClient();

    _jsonSerializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
  }

  public async Task<Guid?> CreateChatAsync(Chat_DTOCreate createChat)
  {
    string json = JsonSerializer.Serialize(createChat, _jsonSerializerOptions);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await _httpClient.PostAsync($"{DataServiceSettings.Address}/chats", content);
    string responseContent = await response.Content.ReadAsStringAsync();
    Guid? guid = JsonSerializer.Deserialize<Guid?>(responseContent, _jsonSerializerOptions);
    return guid;
  }

  public async Task<Chat?> GetChatByIdAsync(Guid chatId)
  {
    HttpResponseMessage response = await _httpClient.GetAsync($"{DataServiceSettings.Address}/chats/{chatId}");
    string responseContent = await response.Content.ReadAsStringAsync();
    Chat? chat = JsonSerializer.Deserialize<Chat?>(responseContent, _jsonSerializerOptions);
    return chat;
  }

  public async Task<Chat?> GetChatByUserIdAndIdAsync(Guid userId, Guid chatId)
  {
    HttpResponseMessage response = await _httpClient.GetAsync($"{DataServiceSettings.Address}users/{userId}/chats/{chatId}");
    string responseContent = await response.Content.ReadAsStringAsync();
    Chat? chat = JsonSerializer.Deserialize<Chat?>(responseContent, _jsonSerializerOptions);
    return chat;
  }

  public async Task<IEnumerable<Chat>?> GetChatsByUserIdAsync(Guid userId)
  {
    HttpResponseMessage response = await _httpClient.GetAsync($"{DataServiceSettings.Address}/{userId}/chats/");
    string responseContent = await response.Content.ReadAsStringAsync();
    IEnumerable<Chat>? chats = JsonSerializer.Deserialize<IEnumerable<Chat>?>(responseContent, _jsonSerializerOptions);
    return chats;
  }
}
