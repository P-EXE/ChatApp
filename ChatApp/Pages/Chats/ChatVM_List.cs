using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChatApp.ViewModels;

public partial class ChatVM_List : ObservableObject
{
  public ChatVM_List()
  {
  }
  public Chat? Chat { get; set; }
  [ObservableProperty]
  private string _name = "NAME";
  [ObservableProperty]
  private string _lastMessage = "LAST_MESSAGE";
  [ObservableProperty]
  private DateTime _lastActivityDateTime = DateTime.UtcNow;
  [ObservableProperty]
  private int _unreadMessagesCount = -1;
}
