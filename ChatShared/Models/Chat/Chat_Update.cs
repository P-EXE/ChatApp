namespace ChatShared.Models;

public class Chat_Update
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string? Description { get; set; }
  public List<Guid> UserIds { get; set; } = [];
}
