namespace ChatShared.Models;

public class Message_Create
{
  public Guid ChatId { get; set; }
  public Guid UserId { get; set; }
  public string Text { get; set; }
}
