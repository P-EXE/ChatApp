namespace ChatShared.Models;

public class Chat_API : IChat
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }

  public ICollection<AppUser> Users { get; set; } = [];
  public ICollection<Message>? Messages { get; set; } = [];
}
