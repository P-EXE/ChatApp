using ChatShared.Models;

namespace ChatApi.Repos;

public interface IUserRepo
{
  Task<AppUser_Read?> GetSelfPublicAsync(AppUser? user);
  Task<AppUser?> GetSelfPrivateAsync(AppUser? user);
  Task<IEnumerable<AppUser_Read>?> GetUsersByNameAsync(string userName);
  Task<IEnumerable<Chat_Read>?> GetUsersChatsAsync(AppUser user);
}
