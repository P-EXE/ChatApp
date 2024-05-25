namespace ChatShared.Models;

public partial interface IChat
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }

  // Generic Collection of AppUser
  // Generic Collection of Message
}
