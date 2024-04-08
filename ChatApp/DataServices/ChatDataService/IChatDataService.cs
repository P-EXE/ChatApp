using ChatShared.Models;

namespace ChatApp.DataServices;

public interface IChatDataService
{
  Task<Guid?> CreateChatAsync(Chat_DTOCreate createChat);
  Task<Chat?> GetChatByIdAsync(Guid chatId);
  Task<Chat?> GetChatByUserIdAndIdAsync(Guid userId, Guid chatId);
  Task<IEnumerable<Chat>?> GetChatsByUserIdAsync(Guid userId);
}
