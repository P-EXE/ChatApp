using Microsoft.AspNetCore.Identity;

namespace ChatShared.Models;

public class AppUser : IdentityUser<Guid>
{
  public ICollection<Chat_API> Chats { get; set; } = [];
  public ICollection<Message_API> Messages { get; set; } = [];
}
