using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repos;

public class UserRepo : IUserRepo
{
  private readonly SQLDBContext _context;
  private readonly IMapper _mapper;

  public UserRepo(SQLDBContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
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

  public async Task<AppUser_DTORead1?> GetUserByIdAsync(Guid userId)
  {
    AppUser? user = await _context.Users.FindAsync(userId);
    AppUser_DTORead1? usersDTORead1 = _mapper.Map<AppUser, AppUser_DTORead1>(user);
    return usersDTORead1;
  }

  public async Task<IEnumerable<AppUser_DTORead1>?> GetUsersByNameAsync(string userName)
  {
    IEnumerable<AppUser>? users = _context.Users
      .Where(u => u.UserName.StartsWith(userName))
      .AsEnumerable();
    IEnumerable<AppUser_DTORead1>? usersDTORead1 = _mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUser_DTORead1>>(users);
    return usersDTORead1;
  }
}
