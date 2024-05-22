using ChatShared.Models;

namespace ChatApi.Repos;

public interface IUserRepo
{
  Task<AppUser?> GetSelfAsync(AppUser? user);
  Task<IEnumerable<Chat_Read>?> GetUsersChatsAsync(AppUser user);
}
