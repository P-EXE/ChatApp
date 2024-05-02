using Microsoft.AspNetCore.Mvc;
using ChatApi.Repos;
using ChatShared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ChatApi.Controllers;

[Route("api/user/chats/{chatId}/messages")]
[ApiController]
public class MessageController : ControllerBase
{
  private readonly UserManager<AppUser> _userManager;
  private readonly IMessageRepo _messageRepo;

  public MessageController(UserManager<AppUser> userManager, IMessageRepo messageRepo)
  {
    _userManager = userManager;
    _messageRepo = messageRepo;
  }

  [HttpPost]
  [Authorize]
  public async Task CreateMessageInChat([FromRoute] Guid chatId, [FromBody] Message_DTOCreate createMessage)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    await _messageRepo.CreateMessageInChatAsync(user, chatId, createMessage);
  }

  [HttpDelete("{messageId}")]
  [Authorize]
  public async Task DeleteMessageInChat([FromRoute] Guid chatId, [FromRoute] int messageId)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    await _messageRepo.DeleteMessageInChatAsync(user, chatId, messageId);
  }

  [HttpGet]
  [Authorize]
  public async Task<IEnumerable<Message_DTORead1>?> GetSomeMessagesInChat([FromRoute] Guid chatId, [FromQuery] int position)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _messageRepo.GetSomeMessagesInChatAsync(chatId, position);
  }
}
