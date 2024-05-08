using ChatShared.Models;

namespace ChatApp.Services;

public interface IChatService
{
  Task<Guid?> CreateChatAsync(Chat_DTOCreate createChat);
  Task<Chat_DTORead2?> GetChatAsync(Guid chatId);
  Task<IEnumerable<Chat_DTORead>?> GetChatsAsync();
}
