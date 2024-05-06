namespace ChatShared.Models;

public class Chat_DTORead2
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public ICollection<AppUser> Users = new HashSet<AppUser>();
  public ICollection<Message> Messages = new HashSet<Message>();
}
