using ChatShared.Models;

namespace ChatApp.DataServices;

internal interface IMessageDataService
{
  Task CreateMessageInChatAsync(Guid chatId, Message_DTOCreate createMessage);
  Task DeleteMessageInChatAsync(Guid chatId, int messageId);
}
