using ChatShared.Models;

namespace ChatApp.Services;

public class ChatService : IChatService
{
  private readonly IHttpService _httpService;
  public ChatService(IHttpService httpService)
  {
    _httpService = httpService;
  }

  public async Task<Guid?> CreateChatAsync(Chat_DTOCreate createChat)
  {
    return await _httpService.PostAsync<Chat_DTOCreate, Guid?>("user/chats", createChat);
  }

  public async Task<Chat_DTORead2?> GetChatAsync(Guid chatId)
  {
    return await _httpService.GetAsync<Chat_DTORead2>($"user/chats/{chatId}");
  }

  public async Task<IEnumerable<Chat_DTORead>?> GetChatsAsync()
  {
    return await _httpService.GetAsync<IEnumerable<Chat_DTORead>?>("user/chats");
  }
}
