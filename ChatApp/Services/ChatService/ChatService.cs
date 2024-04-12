using ChatShared.Models;

namespace ChatApp.Services;

public class ChatService : IChatService
{
  public Task<Guid> CreateChatAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Chat> GetChatAsync(Guid chatId)
  {
    throw new NotImplementedException();
  }
}
