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
  public ChatDetailsVM(IChatService chatService)
  {
    _chatService = chatService;

    WeakReferenceMessenger.Default.Register<PageReturnObjectMessage<AppUser>>(this, (r, m) =>
    {
      AddMember(m.Value);
    });
  }

  async partial void OnActivePageModeChanged(int pageMode)
  {
    switch ((PageMode)pageMode)
    {
      default:
        break;
      case PageMode.View:
        {
          Members = new(Chat.Users);
          _memberIds = new();
          EditMode = false;
          ViewMode = true;
          break;
        }
      case PageMode.Edit:
        {
          break;
        }
      case PageMode.New:
        {
          Chat = new();
          Members = new();
          _memberIds = new();
          EditMode = true;
          ViewMode = false;
          break;
        }
    }
  }

  [ObservableProperty]
  private int _activePageMode;
  [ObservableProperty]
  private bool _editMode;
  [ObservableProperty]
  private bool _viewMode;


  [ObservableProperty]
  private Chat_DTORead _chat;
  [ObservableProperty]
  private ObservableCollection<AppUser> _members;
  private List<Guid> _memberIds;

  [RelayCommand]
  private async Task AddMember(AppUser member)
  {
    if (member.UserName == Statics.AppOwner?.UserName) return;
    foreach (AppUser m in Members)
    {
      if (m.UserName == member.UserName) return;
    }
    Members.Add(member);
    _memberIds.Add(member.Id);
  }

  [RelayCommand]
  private async Task NavToUserSearchPage()
  {
    await Shell.Current.GoToAsync(nameof(UserSearchPage), true, new Dictionary<string, object>
    {
      { "PageMode", UserSearchVM.PageMode.Return }
    });
  }

  [RelayCommand]
  private async Task CreateChat()
  {
    Chat_DTOCreate createChat = new()
    {
      Name = Chat.Name,
      Description = Chat.Description,
      UserIds = _memberIds
    };
    await _chatService.CreateChatAsync(createChat);
  }

  public enum PageMode
  {
    Default = 0,
    View = 1,
    Edit = 2,
    New = 3
  }
}
