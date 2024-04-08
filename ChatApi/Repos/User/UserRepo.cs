using ChatApi.DataContexts;
using ChatShared.Models;

namespace ChatApi.Repos;

public class UserRepo : IUserRepo
{
  private readonly SQLDBContext _context;

  public UserRepo(SQLDBContext context)
  {
    _context = context;
  }

  public async Task<AppUser?> GetUserByIdAsync(Guid userId)
  {
    AppUser? user = await _context.Users.FindAsync(userId);
    return user;
  }
}
