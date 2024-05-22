using Microsoft.AspNetCore.Mvc;
using ChatApi.Repos;
using ChatShared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ChatApi.Controllers;

[Route("api/chat/{chatId}")]
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


}
