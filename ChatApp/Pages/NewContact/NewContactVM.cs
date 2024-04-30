using ChatApp.Pages;
using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class NewContactVM : ObservableObject
{
  private readonly IContactService _contactService;
  public NewContactVM(IContactService contactService)
  {
    _contactService = contactService;
  }

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
  private async Task ShowDetails()
  {
    await Shell.Current.GoToAsync($"./{nameof(UserProfilePage)}", true, new Dictionary<string, object>()
    {
      ["User"] = SelectedUser
    });
  }
}
