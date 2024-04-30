using ChatShared.Models;

namespace ChatApi.Repos;

public interface IUserRepo
{
  Task<AppUser?> GetUserByIdAsync(Guid userId);
  Task<IEnumerable<AppUser>?> GetUsersByNameAsync(string userName);
  Task<IEnumerable<AppUser>?> GetContactsOfUserAsync(Guid userId);
  Task<bool> AddContactToUserAsync(Guid userId, Guid contactId);
}
