using Microsoft.AspNetCore.Identity;

namespace ChatApi.Models
{
  public class User : IdentityUser<Guid>
  {
    public ICollection<User> Contacts = new HashSet<User>();
    public ICollection<Chat> Chats = new HashSet<Chat>();
  }
}
