using ChatApp.Messaging;
using ChatApp.Pages;
using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Maui.Core.Extensions;
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
  [NotifyPropertyChangedFor(nameof(PageModeView))]
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
  private Chat _chat = new();
  [ObservableProperty]
  private ObservableCollection<AppUser>? _members = [];

  // Set Page Mode
  async partial void OnActivePageModeChanged(int newPageMode)
  {
    Members = Chat.Users?.ToObservableCollection();
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

  [RelayCommand]
  public async void SwitchToEditMode()
  {
    ActivePageMode = (int)PageMode.Edit;
  }

  #region Create or Modify Chat
  [RelayCommand]
  public async Task SaveChatChanges()
  {
    switch ((PageMode)ActivePageMode)
    {
      case <= PageMode.Edit:
        {
          UpdateChat();
          break;
        }
      case PageMode.New:
        {
          CreateChat();
          break;
        }
    }
  }

  private async Task CreateChat()
  {
    Members.Add(Statics.AppOwner);
    Chat.Users = Members;
    await _chatService.CreateChatAsync(Chat);
    await NavToChat();
  }

  private async Task UpdateChat()
  {
    await _chatService.UpdateChatAsync(Chat);
    await NavBack();
  }
  #endregion Create or Modify Chat

  private async void AddMember(AppUser user)
  {
    if (user.Id == Statics.AppOwner?.Id)
    {
      return;
    }
    if (!Members.Any(u => u.Id == user.Id))
    {
      Members.Add(user);
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

  private async Task NavBack()
  {
    await Shell.Current.GoToAsync("..");
  }

  private async Task NavToChat()
  {
    await Shell.Current.GoToAsync($"{nameof(ChatPage)}", true, new Dictionary<string, object>()
    {
      { "Chat", Chat }
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
