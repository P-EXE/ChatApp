using Microsoft.AspNetCore.Mvc;
using ChatApi.Repos;
using ChatShared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ChatApi.Controllers;

[Route("api/user/chats")]
[ApiController]
public class ChatController : ControllerBase
{
  private readonly UserManager<AppUser> _userManager;
  private readonly IChatRepo _chatRepo;
  public ChatController(UserManager<AppUser> userManager, IChatRepo chatRepo)
  {
    _userManager = userManager;
    _chatRepo = chatRepo;
  }

  [HttpPost]
  [Authorize]
  public async Task<Guid?> CreateChat([FromBody] Chat_DTOCreate createChat)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _chatRepo.CreateChatAsync(user, createChat);
  }

  [HttpDelete("{chatId}")]
  public async Task DeleteChat([FromRoute] Guid chatId)
  {
    await _chatRepo.DeleteChatAsync(chatId);
  }

  [HttpGet]
  [Authorize]
  public async Task<IEnumerable<Chat_DTORead>?> GetChats()
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _chatRepo.GetChatsOfUserAsync(user);
  }

  [HttpPost("{chatId}/users")]
  public async Task AddUserToChat([FromRoute] Guid chatId, [FromBody] Guid userId)
  {
    await _chatRepo.AddUserToChatAsync(chatId, userId);
  }

  [HttpDelete("{chatId}/users")]
  public async Task RemoveUserFromChat([FromRoute] Guid chatId, [FromBody] Guid userId)
  {
    await _chatRepo.RemoveUserFromChatAsync(chatId, userId);
  }
}
