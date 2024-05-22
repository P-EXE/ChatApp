namespace ChatShared.Models;

public class Chat_Read
{
  public required Guid Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public List<AppUser>? Users { get; set; }
  public List<Message>? Messages { get; set; }
}
