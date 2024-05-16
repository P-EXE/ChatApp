using ChatApp.Messaging;
using ChatApp.Pages;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ChatApp.ViewModels;

[QueryProperty(nameof(Chat), nameof(Chat))]
[QueryProperty(nameof(ActivePageMode), nameof(PageMode))]
public partial class ChatDetailsVM : ObservableObject
{

  public ChatDetailsVM()
  {
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
          break;
        }
      case PageMode.Edit:
        {
          break;
        }
      case PageMode.New:
        {
          Members = new();
          break;
        }
    }
  }

  [ObservableProperty]
  private int _activePageMode;

  [ObservableProperty]
  private Chat_DTORead _chat;

  [ObservableProperty]
  private List<AppUser> _members;

  private async Task AddMember(AppUser member)
  {
    if (!Members.Contains(member))
      Members.Add(member);
  }

  [RelayCommand]
  private async Task NavToUserSearchPage()
  {
    await Shell.Current.GoToAsync(nameof(UserSearchPage), true, new Dictionary<string, object>
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
