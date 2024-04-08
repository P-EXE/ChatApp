using ChatShared.Models;

namespace ChatApi.Repos;

public interface IUserRepo
{
  Task<AppUser?> GetUserByIdAsync(Guid userÍd);
}
