using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChatApp.ViewModels;

public partial class ChatsVM : ObservableObject
{
  public ChatsVM()
  {

  }

  [ObservableProperty]
  private IEnumerable<Chat> _chats;

  private async Task GetChatsAsync()
  {

  }
}
