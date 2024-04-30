using ChatApi.DataContexts;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repos;

public class UserRepo : IUserRepo
{
  private readonly SQLDBContext _context;

  public UserRepo(SQLDBContext context)
  {
    _context = context;
  }

  public async Task<bool> AddContactToUserAsync(Guid userId, Guid contactId)
  {
    AppUser? user = await _context.Users.FindAsync(userId);
    AppUser? contact = await _context.Users.FindAsync(contactId);
    user.Contacts.Add(contact);
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<IEnumerable<AppUser>?> GetContactsOfUserAsync(Guid userId)
  {
    IEnumerable<AppUser>? users = _context.Users
      .Include(u => u.Contacts)
      .Where(u => u.Equals(userId))
      .First()
      .Contacts
      .AsEnumerable();
    return users;
  }

  public async Task<AppUser?> GetUserByIdAsync(Guid userId)
  {
    AppUser? user = await _context.Users.FindAsync(userId);
    return user;
  }

  public async Task<IEnumerable<AppUser>?> GetUsersByNameAsync(string userName)
  {
    IEnumerable<AppUser>? users = _context.Users
      .Where(u => u.UserName.StartsWith(userName))
      .AsEnumerable();
    return users;
  }
}
