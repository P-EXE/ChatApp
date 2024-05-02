using ChatShared.Models;

namespace ChatApi.Repos;

public interface IUserRepo
{
  Task<AppUser_DTORead1?> GetUserByIdAsync(Guid userId);
  Task<IEnumerable<AppUser_DTORead1>?> GetUsersByNameAsync(string userName);
  Task<IEnumerable<AppUser>?> GetContactsOfUserAsync(Guid userId);
  Task<bool> AddContactToUserAsync(Guid userId, Guid contactId);
}
