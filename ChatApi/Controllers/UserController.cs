using AutoMapper;
using ChatApi.DataContexts;
using ChatApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly SQLDBContext _sqldbContext;
  private readonly IMapper _mapper;

  public UserController(SQLDBContext sqldbContext, IMapper mapper)
  {
    _sqldbContext = sqldbContext;
    _mapper = mapper;
  }

  [HttpGet("{userId}")]
  public async Task<User?> GetUserById([FromRoute] Guid userId)
  {
    User? user = await _sqldbContext.Users.FindAsync(userId);
    return user;
  }
}
