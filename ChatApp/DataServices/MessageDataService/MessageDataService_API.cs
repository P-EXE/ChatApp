using ChatShared.Models;
using System.Text;
using System.Text.Json;

namespace ChatApp.DataServices;

internal class MessageDataService_API : IMessageDataService
{
  private readonly HttpClient _httpClient;
  private readonly JsonSerializerOptions _jsonSerializerOptions;

  public MessageDataService_API()
  {
    _httpClient = new HttpClient();

    _jsonSerializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
  }

  public async Task CreateMessageInChatAsync(Guid chatId, Message_DTOCreate createMessage)
  {
    string json = JsonSerializer.Serialize(createMessage, _jsonSerializerOptions);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await _httpClient.PostAsync($"{DataServiceSettings.Address}/chats/{chatId}/messages", content);
  }

  public async Task DeleteMessageInChatAsync(Guid chatId, int messageId)
  {
    HttpResponseMessage response = await _httpClient.GetAsync($"{DataServiceSettings.Address}/chats/{chatId}/messages/{messageId}");
  }
}
