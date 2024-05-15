using ChatShared.Models;

namespace ChatApi.Repos;

public interface IMessageRepo
{
  Task CreateMessageInChatAsync(AppUser user, Guid chatId, Message_DTOCreate createMessage);
  Task DeleteMessageInChatAsync(AppUser user, Guid chatId, int messageId);
  Task<IEnumerable<Message_DTORead>?> GetSomeMessagesInChatAsync(Guid chatId, int position);
}
