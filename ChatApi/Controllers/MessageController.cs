using Microsoft.AspNetCore.Mvc;
using ChatApi.Repos;
using ChatShared.Models;

namespace ChatApi.Controllers;

[Route("api/user/chats/{chatId}/messages")]
[ApiController]
public class MessageController : ControllerBase
{
  private readonly IMessageRepo _messageRepo;

  public MessageController(IMessageRepo messageRepo)
  {
    _messageRepo = messageRepo;
  }

  [HttpPost]
  public async Task CreateMessageInChat([FromRoute] Guid chatId, [FromBody] Message_DTOCreate createMessage)
  {
    await _messageRepo.CreateMessageInChatAsync(chatId, createMessage);
  }

  [HttpDelete("{messageId}")]
  public async Task DeleteMessageInChat([FromRoute] Guid chatId, [FromRoute] int messageId)
  {
    await _messageRepo.DeleteMessageInChatAsync(chatId, messageId);
  }
}
