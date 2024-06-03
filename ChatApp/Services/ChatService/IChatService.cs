using ChatShared.Models;
using System.Collections.ObjectModel;

namespace ChatApp.Services;

public interface IChatService
{
  Task<Chat?> CreateChatAsync(Chat chat);
  Task<Chat?> UpdateChatAsync(Chat chat);
  Task<IEnumerable<Chat>?> GetChatsAsync();
}
