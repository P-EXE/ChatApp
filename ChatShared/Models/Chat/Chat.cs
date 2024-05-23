namespace ChatShared.Models;

public class Chat
{
  public required Guid Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }

  public ICollection<AppUser> Users { get; set; } = [];
  public ICollection<Message>? Messages { get; set; } = [];
}
