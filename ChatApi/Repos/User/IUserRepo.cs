using ChatShared.Models;

namespace ChatApi.Repos;

public interface IUserRepo
{
  Task<AppUser_Read?> GetSelfAsync(AppUser? user);
  Task<IEnumerable<Chat_Read>?> GetUsersChatsAsync(AppUser user);
}
