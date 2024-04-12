using ChatShared.Models;

namespace ChatApp.Models;

public class ChatInfo
{
  private Chat Chat {  get; set; }
  private string Name { get; set; }
  private string Description { get; set; }
  private string LatestMessage { get; set; }
  private DateTime LatestMessageTimeStamp { get; set; }
  private int UnreadMessagesCount { get; set; }
}
