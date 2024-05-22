using ChatShared.Models;

namespace ChatApp.Services;

public class MessageService : IMessageService
{
  private readonly IHttpService _httpService;
  public MessageService(IHttpService httpService)
  {
    _httpService = httpService;
  }

  public async Task<IEnumerable<Message>?> GetMessagesOfChatAsync(string chatId, int position)
  {
    return await _httpService.GetAsync<IEnumerable<Message>>($"user/chats/{chatId}/messages?position={position}");
  }

  public async Task SendMessageToChatAsync(string chatId, Message_DTOCreate message)
  {
    await _httpService.PostAsync($"user/chats/{chatId}/messages", message);
  }
}
