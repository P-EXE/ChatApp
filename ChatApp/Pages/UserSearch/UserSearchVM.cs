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

[QueryProperty(nameof(ActivePageMode), nameof(PageMode))]
public partial class UserSearchVM : ObservableObject
{
  private readonly IUserService _contactService;

  /// <summary>
  /// Switch between Page Modes and set bool values for the View
  /// </summary>
  [ObservableProperty]
  private int _activePageMode;
  [ObservableProperty]
  private bool _pageModeReturn;
  public bool PageModeView => !PageModeReturn;

  public UserSearchVM(IUserService contactService)
  {
    _contactService = contactService;
  }

  [ObservableProperty]
  private string _searchText;
  [ObservableProperty]
  private ObservableCollection<AppUser>? _users = [];
  [ObservableProperty]
  private AppUser? _selectedUser;

  [RelayCommand]
  private async Task Search()
  {
    IEnumerable<AppUser>? users = await _contactService.GetUsersByNameAsync(SearchText);
    Users = users?.ToObservableCollection();
  }

  #region View or Return selected User
  [RelayCommand]
  public async Task UserSelected()
  {
    switch ((PageMode)ActivePageMode)
    {
      case PageMode.View:
        {
          await NavigateToUserProfilePage();
          break;
        }
      case PageMode.Return:
        {
          await ReturnSelection();
          break;
        }
    }
  }

  private async Task NavigateToUserProfilePage()
  {
    await Shell.Current.GoToAsync($"./{nameof(UserProfilePage)}", true, new Dictionary<string, object>()
    {
      {"User", SelectedUser }
    });
  }

  private async Task ReturnSelection()
  {
    WeakReferenceMessenger.Default.Send(new PageReturnObjectMessage<AppUser>(SelectedUser));
    await Shell.Current.GoToAsync($"..");
  }
  #endregion View or Return selected User

  public enum PageMode
  {
    Default = 0,
    View = 1,
    Return = 2,
  }
}
