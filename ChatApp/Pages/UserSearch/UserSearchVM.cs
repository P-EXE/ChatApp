using ChatApp.Messaging;
using ChatApp.Pages;
using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ChatApp.ViewModels;

[QueryProperty(nameof(ActivePageMode), nameof(PageMode))]
public partial class UserSearchVM : ObservableObject
{
  private readonly IContactService _contactService;
  public UserSearchVM(IContactService contactService)
  {
    _contactService = contactService;
  }

  [ObservableProperty]
  private int _activePageMode;
  [ObservableProperty]
  private string _searchText;
  [ObservableProperty]
  private IEnumerable<AppUser>? _users;
  [ObservableProperty]
  private AppUser? _selectedUser;

  [RelayCommand]
  private async Task Search()
  {
    Users = await _contactService.GetUsersByNameAsync(SearchText);
  }

  [RelayCommand]
  private async Task Selected()
  {
    switch ((PageMode)ActivePageMode)
    {
      default:
        break;
      case PageMode.Default:
        {
          break;
        }
      case PageMode.Details:
        {
          await ShowDetails();
          break;
        }
      case PageMode.Return:
        {
          await ReturnSelection();
          break;
        }
    }
  }

  private async Task ReturnSelection()
  {
    WeakReferenceMessenger.Default.Send(new PageReturnObjectMessage<AppUser>(SelectedUser));
    await Shell.Current.GoToAsync($"..");
  }

  private async Task ShowDetails()
  {
    await Shell.Current.GoToAsync($"./{nameof(UserProfilePage)}", true, new Dictionary<string, object>()
    {
      ["User"] = SelectedUser
    });
  }

  public enum PageMode
  {
    Default = 0,
    Details = 1,
    Return = 2,
  }
}
