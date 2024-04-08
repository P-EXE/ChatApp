using CommunityToolkit.Mvvm.ComponentModel;
using ChatShared.Models;

namespace ChatApp.ViewModels;

public partial class ChatsVM : ObservableObject
{
  [ObservableProperty]
  private IEnumerable<Chat> _chats;
}
