using ChatShared.Models;

namespace ChatApi.Repos;

public interface IChatRepo
{
  Task CreateChatAsync(Chat_DTOCreate createChat);
  Task DeleteChatAsync(Guid chatId);
  Task AddUserToChatAsync(Guid chatId, Guid userId);
  Task RemoveUserFromChatAsync(Guid chatId, Guid userId);
}
