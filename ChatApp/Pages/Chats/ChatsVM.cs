using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class ChatsVM : ObservableObject
{
  public ChatsVM()
  {
    GetMockChatsAsync();
  }

  [ObservableProperty]
  private List<ChatVM_List> _chats = new();
  [ObservableProperty]
  private bool _isRefreshing;

  [RelayCommand]
  private async Task Refresh()
  {
    IsRefreshing = true;
    GetMockChatsAsync();
    IsRefreshing = false;
  }

  private void GetMockChatsAsync()
  {
    ChatVM_List chat = new() { Name = "Hallo" };
    for (int i = 0; i <= 10; i++)
    {
      Chats.Add(chat);
    }
  }
}
