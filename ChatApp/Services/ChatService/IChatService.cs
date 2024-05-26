using ChatShared.Models;
using System.Collections.ObjectModel;

namespace ChatApp.Services;

public interface IChatService
{
  Task<Chat_MAUI?> CreateChatAsync(Chat_MAUI chat);
  Task<Chat_MAUI?> UpdateChatAsync(Chat_MAUI chat);
  Task<IEnumerable<Chat_MAUI>?> GetChatsAsync();
}
