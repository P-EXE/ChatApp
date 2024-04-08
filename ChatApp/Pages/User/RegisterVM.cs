using ChatApp.DataServices;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class RegisterVM : ObservableObject
{
  private readonly IUserDataService _userDataService;
  public RegisterVM(IUserDataService userDataService)
  {
    _userDataService = userDataService;
  }

  [ObservableProperty]
  private string _email;
  [ObservableProperty]
  private string _password;
  [ObservableProperty]
  private bool _available;

  [RelayCommand]
  public async Task Register()
  {
    AppUser_DTOCreate userCreate = new AppUser_DTOCreate()
    {
      Email = Email,
      Password = Password
    };

    AppUser? user = await _userDataService.CreateUserAsync(userCreate);
    if (user == null)
    {
      return;
    }

    await Shell.Current.Navigation.PopAsync();
  }
}
