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

  #region Self
  public async Task<AppUser_Read?> GetSelfPublicAsync(AppUser? user)
  {
    if (user == null) return null;
    AppUser? retUser = await _context.Users.FindAsync(user.Id);
    return _mapper.Map<AppUser_Read>(retUser);
  }
  public async Task<AppUser?> GetSelfPrivateAsync(AppUser? user)
  {
    if (user == null) return null;
    user = await _context.Users
      .Include(u => u.Chats).Include(u => u.Messages)
      .FirstAsync(u => u.Id == user.Id);
    return _mapper.Map<AppUser_Read>(user);
  }
  #endregion Self

  public async Task<IEnumerable<AppUser_Read>?> GetUsersByNameAsync(string userName)
  {
    IEnumerable<AppUser>? users = _context.Users
      .Where(u => u.UserName.StartsWith(userName))
      .AsEnumerable();

    return _mapper.Map<IEnumerable<AppUser_Read>?>(users);
  }

  public async Task<IEnumerable<Chat_Read>?> GetUsersChatsAsync(AppUser user)
  {
    IEnumerable<Chat_API> chats = _context.Users
      .Include(u => u.Chats).ThenInclude(c => c.Users)
      .Where(u => u.Id == user.Id)
      .First()
      .Chats
      .AsEnumerable();

    return _mapper.Map<IEnumerable<Chat_Read>?>(chats);
  }
}
