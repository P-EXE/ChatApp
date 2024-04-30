using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;

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

  public async Task<AppUser_DTORead1?> GetUserByIdAsync(Guid userId)
  {
    AppUser? user = await _context.Users.FindAsync(userId);
    AppUser_DTORead1? usersDTORead1 = _mapper.Map<AppUser, AppUser_DTORead1>(user);
    return usersDTORead1;
  }

  public async Task<IEnumerable<AppUser_DTORead1>?> GetUsersByNameAsync(string userName)
  {
    IEnumerable<AppUser>? users = _context.Users
      .Where(u => u.UserName.StartsWith(userName))
      .AsEnumerable();
    IEnumerable<AppUser_DTORead1>? usersDTORead1 = _mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUser_DTORead1>>(users);
    return usersDTORead1;
  }
}
