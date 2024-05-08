namespace ChatShared.Models;

public class Chat_DTORead
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public IEnumerable<AppUser> Users {  get; set; }
  public IEnumerable<Message> Messages { get; set; }
}
