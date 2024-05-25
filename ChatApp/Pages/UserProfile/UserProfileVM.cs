using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

[QueryProperty("User", "User")]
public partial class UserProfileVM : ObservableObject
{
  private readonly IUserService _contactService;
  public UserProfileVM(IUserService contactService)
  {
    _contactService = contactService;
  }

  [ObservableProperty]
  private AppUser _user;

  [RelayCommand]
  private async Task AddToContacts()
  {
    throw new NotImplementedException();
  }
}
