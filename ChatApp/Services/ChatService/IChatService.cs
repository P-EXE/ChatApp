using ChatShared.Models;

namespace ChatApp.Services;

public interface IChatService
{
  Task<Chat_Read?> CreateChatAsync(Chat_Create createChat);
  Task<List<Chat_Read>?> GetChatsAsync();
}
