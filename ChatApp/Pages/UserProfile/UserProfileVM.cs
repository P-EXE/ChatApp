using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

[QueryProperty("User", "User")]
public partial class UserProfileVM : ObservableObject
{
  private readonly IContactService _contactService;
  public UserProfileVM(IContactService contactService)
  {
    _contactService = contactService;
  }

  [ObservableProperty]
  private AppUser _user;

  [RelayCommand]
  private async Task AddToContacts()
  {
    _ = await _contactService.AddUserToContacts(User.Id.ToString());
  }
}
