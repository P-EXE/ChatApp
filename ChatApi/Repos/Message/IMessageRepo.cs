using ChatShared.Models;

namespace ChatApi.Repos;

public interface IMessageRepo
{
  Task<Message?> CreateMessageInChatAsync(Message message);
}
