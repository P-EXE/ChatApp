using Microsoft.AspNetCore.Identity;

namespace ChatShared.Models;

public class AppUser : IdentityUser<Guid>
{
  public ICollection<Chat> Chats { get; set; } = [];
}
