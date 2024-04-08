namespace ChatShared.Models;

public class Message
{
  public Guid ChatId { get; set; }
  public Chat Chat { get; set; }
  public Guid SenderId { get; set; }
  public AppUser Sender { get; set; }
  public int MessageId { get; set; }
  public string Text { get; set; }
}
