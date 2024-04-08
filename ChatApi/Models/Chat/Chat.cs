using Microsoft.EntityFrameworkCore;

namespace ChatApi.Models;

public class Chat
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public ICollection<User> Users = new HashSet<User>();
  public ICollection<Message> Messages = new HashSet<Message>();
}
