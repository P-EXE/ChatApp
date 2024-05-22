using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;

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
    if(user == null) return null;
    return await _context.Users.FindAsync(user.Id);
  }

  public async Task<IEnumerable<Chat_Read>?> GetUsersChatsAsync(AppUser user)
  {
    IEnumerable<Chat>? chats = _context.Users
      .Include(u => u.Chats).ThenInclude(c => c.Users)
      .Where(u => u == user)
      .First()
      .Chats
      .AsEnumerable();
    IEnumerable<Chat_Read>? returnChats = _mapper.Map<IEnumerable<Chat_Read>>(chats);

    return returnChats;
  }
}
