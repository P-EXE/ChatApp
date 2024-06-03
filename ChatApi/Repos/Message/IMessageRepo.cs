using ChatShared.Models;

namespace ChatApi.Repos;

public interface IMessageRepo
{
  Task<Message_Read?> CreateMessageInChatAsync(Message_Create createMessage);
  Task<IEnumerable<Message_Read>?> GetSomeMessagesInChatAsync(Guid chatId, int position);
}
