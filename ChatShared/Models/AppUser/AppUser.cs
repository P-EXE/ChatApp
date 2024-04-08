using Microsoft.AspNetCore.Identity;

namespace ChatShared.Models;

public class AppUser : IdentityUser<Guid>
{
  public ICollection<AppUser> Contacts = new HashSet<AppUser>();
  public ICollection<Chat> Chats = new HashSet<Chat>();
}
