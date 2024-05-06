using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

[QueryProperty("Chat", "Chat")]
public partial class ChatVM : ObservableObject
{
  private readonly IChatService _chatService;
  public ChatVM(IChatService chatService)
  {
    _chatService = chatService;
  }

  [ObservableProperty]
  private Chat _chat;

  [ObservableProperty]
  private IEnumerable<Message>? _messages;
  [ObservableProperty]
  private int _position = 0;

  [RelayCommand]
  private async Task GetMessages()
  {

  }

  [RelayCommand]
  private async Task SendMessage()
  {

  }

  [RelayCommand]
  private async Task NavToChatDetails()
  {

  }
}
