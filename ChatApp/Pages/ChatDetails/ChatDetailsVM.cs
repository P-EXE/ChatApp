using ChatApp.Messaging;
using ChatApp.Models;
using ChatApp.Pages;
using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;

namespace ChatApp.ViewModels;

[QueryProperty("Chat", nameof(Chat))]
[QueryProperty(nameof(ActivePageMode), nameof(PageMode))]
public partial class ChatDetailsVM : ObservableObject
{
  private readonly IChatService _chatService;

  /// <summary>
  /// Switch between Page Modes and set bool values for the View
  /// </summary>
  [ObservableProperty]
  private int _activePageMode;
  [ObservableProperty]
  private bool _pageModeEdit;
  public bool PageModeView => !PageModeEdit;

  public ChatDetailsVM(IChatService chatService)
  {
    _chatService = chatService;

    WeakReferenceMessenger.Default.Register<PageReturnObjectMessage<AppUser>>(this, (r, m) =>
    {
      AddMember(m.Value);
    });
  }

  [ObservableProperty]
  private Chat_MAUI _chat = new();

  // Set Page Mode
  async partial void OnActivePageModeChanged(int newPageMode)
  {
    switch ((PageMode)newPageMode)
    {
      case PageMode.Edit:
        {
          PageModeEdit = true;
          break;
        }
      case PageMode.New:
        {
          PageModeEdit = true;
          break;
        }
    }
  }

  #region Create or Modify Chat
  [RelayCommand]
  public async Task SaveChatChanges()
  {
    switch ((PageMode)ActivePageMode)
    {
      case PageMode.Edit:
        {
          break;
        }
      case PageMode.New:
        {
          break;
        }
    }
  }

  private async Task CreateChat()
  {
    throw new NotImplementedException();
  }

  private async Task UpdateChat()
  {
    throw new NotImplementedException();
  }
  #endregion Create or Modify Chat

  private async void AddMember(AppUser user)
  {
    if (user.Id == Statics.AppOwner?.Id)
    {
      return;
    }
    if (!Chat.Users.Any(u => u.Id == user.Id))
    {
      Chat.Users.Add(user);
    }
  }

  [RelayCommand]
  public async Task NavToUserSearchPage()
  {
    await Shell.Current.GoToAsync($"{nameof(UserSearchPage)}", true, new Dictionary<string, object>
    {
      { "PageMode", UserSearchVM.PageMode.Return }
    });
  }

  public enum PageMode
  {
    Default = 0,
    View = 1,
    Edit = 2,
    New = 3
  }
}
