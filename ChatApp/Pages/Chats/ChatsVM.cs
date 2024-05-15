using ChatApp.Pages;
using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
  private IEnumerable<Chat_DTORead>? _chatPreviews;
  [ObservableProperty]
  private IEnumerable<Chat_DTORead>? _chats;
  [ObservableProperty]
  private Chat_DTORead? _selectedChat;
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
    await Shell.Current.GoToAsync(nameof(ChatDetailsPage));
  }

  [RelayCommand]
  private async Task NavToChat()
  {
    await Shell.Current.GoToAsync(nameof(ChatPage), true, new Dictionary<string, object>
    {
      [nameof(Chat)] = SelectedChat,
    });
    SelectedChat = null;
  }

  private async Task GenerateChatPreviews()
  {

  }
}
