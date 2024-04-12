using ChatApp.Models;
using ChatApp.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class ChatsVM : ObservableObject
{
  public ChatsVM()
  {
  }

  [ObservableProperty]
  private List<ChatInfo> _chats;
  [ObservableProperty]
  private bool _chatList_isRefreshing;

  [RelayCommand]
  private async Task RefreshChatList()
  {
  }

  [RelayCommand]
  private async Task CreateNewChat()
  {
    await Shell.Current.GoToAsync(nameof(NewChatPage));
  }
}
