namespace ChatShared.Models;

public class Message_DTORead1
{
  public Guid ChatId { get; set; }
  public Guid SenderId { get; set; }
  public int MessageId { get; set; }
  public string? Text { get; set; }
}
