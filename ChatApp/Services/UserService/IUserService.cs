using ChatShared.Models;

namespace ChatApp.Services;

public interface IUserService
{
  Task<IEnumerable<AppUser>?> GetUsersByNameAsync(string userName);
}
