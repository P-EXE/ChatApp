using ChatShared.Models;

namespace ChatApi.Repos;
/// <summary>
/// CRUD Operations for Chat Entities
/// Reflects Changes
/// </summary>
public interface IChatRepo
{
  Task<Chat_Read?> CreateChatAsync(Chat_Create chat);
  Task<Chat_Read?> ReadChatAsync(Guid id);
  Task<Chat_Read?> UpdateChatAsync(Chat_Update chat);
  Task<bool> DeleteChatAsync(Guid id);

  // Debuging
  Task<IEnumerable<Chat>?> ReadAllChatsAsync();
}
