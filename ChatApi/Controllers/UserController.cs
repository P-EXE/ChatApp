﻿using ChatApi.Repos;
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
}
