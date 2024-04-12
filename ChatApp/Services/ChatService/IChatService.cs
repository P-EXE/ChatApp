using ChatShared.Models;

namespace ChatApp.Services;

public interface IChatService
{
  Task<Guid> CreateChatAsync();
  Task<Chat> GetChatAsync(Guid chatId);
}
