using Microsoft.EntityFrameworkCore;

namespace ChatApi.Models
{
  public class Message
  {
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
    public int MessageId { get; set; }
  }
}
