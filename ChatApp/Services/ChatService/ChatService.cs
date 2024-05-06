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
    await _httpService.PostAsync("user/chats", createChat);
    return null;
  }

  public Task<Chat> GetChatAsync(Guid chatId)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<Chat_DTORead1>?> GetChatsAsync()
  {
    return await _httpService.GetAsync<IEnumerable<Chat_DTORead1>?>("user/chats");
  }
}
