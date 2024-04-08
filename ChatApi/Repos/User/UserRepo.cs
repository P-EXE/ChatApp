using ChatApi.DataContexts;
using ChatApi.Models;

namespace ChatApi.Repos;

public class UserRepo : IUserRepo
{
  private readonly SQLDBContext _context;

  public UserRepo(SQLDBContext context)
  {
    _context = context;
  }

  public async Task<User?> GetUserById(Guid userId)
  {
    User? user = await _context.Users.FindAsync(userId);
    return user;
  }
}
