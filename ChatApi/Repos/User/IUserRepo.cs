using ChatApi.Models;

namespace ChatApi.Repos;

public interface IUserRepo
{
  Task<User?> GetUserById(Guid userÍd);
}
