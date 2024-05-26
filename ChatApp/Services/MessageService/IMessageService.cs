using ChatShared.Models;

namespace ChatApp.Services;

public interface IMessageService
{
  Task<IEnumerable<Message_MAUI>?> GetMessagesOfChatAsync(string chatId, int position);
  Task<Message_MAUI?> SendMessageToChatAsync(Message_MAUI message);
}
