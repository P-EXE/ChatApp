using Microsoft.AspNetCore.Mvc;
using ChatApi.Repos;
using ChatShared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ChatApi.Controllers;
/// <summary>
/// Controller for Chat Entities
/// F*ck DTOs
/// F*ck Routes
/// </summary>
[Route("api/chat")]
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

  [Authorize]
  [HttpPost]
  public async Task<Chat_Read?> CreateChat([FromBody] Chat_Create chat)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _chatRepo.CreateChatAsync(chat);
  }


  [Authorize]
  [HttpGet("{id}")]
  public async Task<Chat_Read?> GetChat([FromRoute] Guid id)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _chatRepo.ReadChatAsync(id);
  }

  [Authorize]
  [HttpPut]
  public async Task<Chat_Read?> UpdateChat([FromBody] Chat_Edit chat)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _chatRepo.UpdateChatAsync(chat);
  }

  [Authorize]
  [HttpDelete("{id}")]
  public async Task<bool> DeleteChat([FromRoute] Guid id)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _chatRepo.DeleteChatAsync(id);
  }
}
