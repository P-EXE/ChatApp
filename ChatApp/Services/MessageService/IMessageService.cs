using ChatShared.Models;

namespace ChatApp.Services;

public interface IMessageService
{
  Task<IEnumerable<Message>?> GetMessagesOfChatAsync(string chatId, int position);
  Task SendMessageToChatAsync(string chatId, Message_DTOCreate message);
}
