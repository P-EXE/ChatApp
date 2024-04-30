using ChatApi.Repos;
using Microsoft.AspNetCore.Mvc;
using ChatShared.Models;

namespace ChatApi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IUserRepo _userRepo;

  public UserController(IUserRepo userRepo)
  {
    _userRepo = userRepo;
  }

  [HttpGet("{userId}")]
  public async Task<AppUser?> GetUserById([FromRoute] Guid userId)
  {
    return await _userRepo.GetUserByIdAsync(userId);
  }

  [HttpGet]
  public async Task<IEnumerable<AppUser>?> GetUsersByName([FromQuery] string name)
  {
    return await _userRepo.GetUsersByNameAsync(name);
  }

  [HttpPost("{userId}/contacts")]
  public async Task GetContactsOfUser([FromRoute] Guid userId, [FromBody] Guid contactId)
  {
    await _userRepo.AddContactToUserAsync(userId, contactId);
  }

  [HttpGet("{userId}/contacts")]
  public async Task<IEnumerable<AppUser>?> GetContactsOfUser([FromRoute] Guid userId)
  {
    return await _userRepo.GetContactsOfUserAsync(userId);
  }
}
