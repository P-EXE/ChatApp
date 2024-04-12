namespace ChatShared.Models;

public class Chat_DTOCreate
{
  public required string Name { get; set; }
  public required string Description { get; set; }
  public required IEnumerable<Guid>? UserIds { get; set; }
}
