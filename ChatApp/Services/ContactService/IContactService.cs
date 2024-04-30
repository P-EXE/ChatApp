using ChatShared.Models;

namespace ChatApp.Services;

public interface IContactService
{
  Task<IEnumerable<AppUser>?> GetUsersByNameAsync(string userName);
  Task<bool> AddUserToContacts(string userId);
}
