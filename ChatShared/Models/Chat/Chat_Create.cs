namespace ChatShared.Models;

public class Chat_Create
{
  public string Name { get; set; }
  public string? Description { get; set; }
  public List<Guid> UserIds { get; set; } = [];
}
