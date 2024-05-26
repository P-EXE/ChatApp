namespace ChatShared.Models;

public partial interface IMessage
{
  public Guid ChatId { get; set; }
  // Generic Chat
  public Guid UserId { get; set; }
  public int MessageId { get; set; }
  public string Text { get; set; }
}
