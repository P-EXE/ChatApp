namespace ChatShared.Models;

public class Chat_Update
{
  public required Guid Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public required List<Guid> UserIds { get; set; }
}
