using ChatApp.Models;
using ChatApp.Pages;
using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ChatApp.ViewModels;

public partial class ChatsVM : ObservableObject
{
  private readonly IChatService _chatService;
  public ChatsVM(IChatService chatService)
  {
    _chatService = chatService;
    RefreshChatList();
  }

  [ObservableProperty]
  private IEnumerable<Chat_DTORead1>? _chats;
  [ObservableProperty]
  private Chat_DTORead1? _selectedChat;
  [ObservableProperty]
  private bool _chatList_isRefreshing;

  [RelayCommand]
  private async Task RefreshChatList()
  {
    Chats = await _chatService.GetChatsAsync();
  }

  [RelayCommand]
  private async Task CreateNewChat()
  {
    await Shell.Current.GoToAsync(nameof(NewChatPage));
  }

  [RelayCommand]
  private async Task NavToChat()
  {
    Chat? chat = await _chatService.GetChatAsync(SelectedChat.Id);
    await Shell.Current.GoToAsync(nameof(ChatPage), true, new Dictionary<string, object>
    {
      [nameof(Chat)] = chat,
    });
    SelectedChat = null;
  }
}
