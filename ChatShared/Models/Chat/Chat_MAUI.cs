using System.Collections.ObjectModel;

namespace ChatShared.Models;

public class Chat_MAUI : IChat
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }

  public ObservableCollection<AppUser>? Users { get; set; } = [];
  public ObservableCollection<Message_API>? Messages { get; set; } = [];
}
