using ChatApi.Repos;
using Microsoft.AspNetCore.Mvc;
using ChatShared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ChatApi.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly UserManager<AppUser> _userManager;
  private readonly IUserRepo _userRepo;

  public UserController(UserManager<AppUser> userManager, IUserRepo userRepo)
  {
    _userManager = userManager;
    _userRepo = userRepo;
  }

  [Authorize]
  [HttpGet]
  public async Task<AppUser_Read?> GetSelf()
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _userRepo.GetSelfAsync(user);
  }

  [Authorize]
  [HttpGet("chats")]
  public async Task<IEnumerable<Chat_Read>?> GetOwnChats()
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _userRepo.GetUsersChatsAsync(user);
  }
}
