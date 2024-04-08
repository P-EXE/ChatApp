namespace ChatApi.Models;

public class Message_DTOCreate
{
  public Guid SenderId { get; set; }
  public string Text { get; set; }
}
