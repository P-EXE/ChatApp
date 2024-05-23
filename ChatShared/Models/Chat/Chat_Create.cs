namespace ChatShared.Models;

public class Chat_Create
{
  public required string Name { get; set; }
  public string? Description { get; set; }
  public required List<Guid> UserIds { get; set; }
}
