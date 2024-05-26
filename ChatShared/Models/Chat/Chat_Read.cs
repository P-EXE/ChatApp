namespace ChatShared.Models;

public class Chat_Read
{
  public required Guid Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public IEnumerable<AppUser>? Users { get; set; }
  public IEnumerable<Message_API>? Messages { get; set; }
}
