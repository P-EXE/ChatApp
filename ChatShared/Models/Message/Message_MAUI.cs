﻿namespace ChatShared.Models;

public class Message_MAUI : IMessage
{
  public Guid ChatId { get; set; }
  public Chat_MAUI Chat { get; set; }
  public Guid UserId { get; set; }
  public AppUser User { get; set; }
  public int MessageId { get; set; }
  public string Text { get; set; }
}
