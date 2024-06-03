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

  #region Self
  [Authorize]
  [HttpGet("self/reflect")]
  public async Task<AppUser?> Reflect()
  {
    return await _userManager.GetUserAsync(HttpContext.User);
  }

  [Authorize]
  [HttpGet("self/public")]
  public async Task<AppUser_Read?> GetSelfPublic()
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _userRepo.GetSelfPublicAsync(user);
  }

  [Authorize]
  [HttpGet("self/private")]
  public async Task<AppUser?> GetSelfPrivate()
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _userRepo.GetSelfPrivateAsync(user);
  }
  #endregion Self

  [Authorize]
  [HttpGet]
  public async Task<IEnumerable<AppUser_Read>?> GetUserByName([FromQuery] string userName)
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _userRepo.GetUsersByNameAsync(userName);
  }

  [Authorize]
  [HttpGet("chats")]
  public async Task<IEnumerable<Chat_Read>?> GetOwnChats()
  {
    AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
    return await _userRepo.GetUsersChatsAsync(user);
  }
}
