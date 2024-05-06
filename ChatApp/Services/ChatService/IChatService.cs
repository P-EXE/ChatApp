using ChatShared.Models;

namespace ChatApp.Services;

public interface IChatService
{
  Task<Guid?> CreateChatAsync(Chat_DTOCreate createChat);
  Task<Chat> GetChatAsync(Guid chatId);
}
