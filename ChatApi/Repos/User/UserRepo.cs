using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OpenApi.Any;

namespace ChatApi.Repos;

public class UserRepo : IUserRepo
{
  private readonly SQLDBContext _context;
  private readonly IMapper _mapper;

  public UserRepo(SQLDBContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<AppUser?> GetSelfAsync(AppUser? user)
  {
    if (user == null) return null;
    return await _context.Users.FindAsync(user.Id);
  }
  /// <summary>
  /// Get the Chats a User is part of.
  /// Includes other Users in this Chat.
  /// </summary>
  /// <param name="user">The User which Chats will be evaluated</param>
  /// <returns></returns>
  public async Task<IEnumerable<Chat_Read>?> GetUsersChatsAsync(AppUser user)
  {
    IEnumerable<Chat> chats = _context.Users
      .Include(u => u.Chats).ThenInclude(c => c.Users)
      .Where(u => u.Id == user.Id)
      .First()
      .Chats
      .AsEnumerable();

    return _mapper.Map<IEnumerable<Chat_Read>?>(chats);
  }
}
