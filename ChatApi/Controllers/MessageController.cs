using Microsoft.AspNetCore.Mvc;
using ChatApi.Repos;
using ChatShared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ChatApi.Controllers;

[Route("api/chat/messages")]
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
  public async Task CreateMessageInChat([FromBody] Message_Create createMessage)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    await _messageRepo.CreateMessageInChatAsync(createMessage);
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task DeleteMessageInChat([FromRoute] Guid chatId, [FromRoute] int id)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    await _messageRepo.DeleteMessageInChatAsync(user, chatId, id);
  }

  [HttpGet]
  [Authorize]
  public async Task<IEnumerable<Message_Read>?> GetSomeMessagesInChat([FromRoute] Guid chatId, [FromQuery] int position)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _messageRepo.GetSomeMessagesInChatAsync(chatId, position);
  }
}
