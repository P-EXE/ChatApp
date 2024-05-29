﻿using ChatApp.Pages;
using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

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
  private ObservableCollection<Chat>? _chats = new();
  [ObservableProperty]
  private Chat _selectedChat;
  [ObservableProperty]
  private bool _chatList_isRefreshing;

  [RelayCommand]
  private async Task RefreshChatList()
  {
    IEnumerable<Chat>? chats = await _chatService.GetChatsAsync();
    Chats = new(chats);
  }

  [RelayCommand]
  private async Task CreateNewChat()
  {
    await Shell.Current.GoToAsync(nameof(ChatDetailsPage), true, new Dictionary<string, object>
    {
      { "PageMode", ChatDetailsVM.PageMode.New }
    });
  }

  [RelayCommand]
  private async Task NavToChat()
  {
    await Shell.Current.GoToAsync(nameof(ChatPage), true, new Dictionary<string, object>
    {
      { "Chat", SelectedChat }
    });
    SelectedChat = null;
  }

  private async Task GenerateChatPreviews()
  {

  }
}
