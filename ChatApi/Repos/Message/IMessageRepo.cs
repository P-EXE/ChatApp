using ChatApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Repos;

public interface IMessageRepo
{
  Task CreateMessageInChatAsync(Guid chatId, Message_DTOCreate createMessage);
  Task DeleteMessageInChatAsync(Guid chatId, int messageId);
}
