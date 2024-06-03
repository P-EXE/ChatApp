namespace ChatShared.Models;

public class Message_Read
{
  public Chat Chat { get; set; }
  public AppUser User { get; set; }
  public int MessageId { get; set; }
  public string? Text { get; set; }
}
