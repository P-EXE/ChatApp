using ChatApp.DataServices;
using ChatApp.Pages;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

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
  private bool _available = true;

  [RelayCommand]
  public async Task Register()
  {
    AppUser_DTOCreate userCreate = new AppUser_DTOCreate()
    {
      Email = Email,
      Password = Password
    };

    bool success = await _userDataService.CreateUserAsync(userCreate);

    if (success)
    {
      await NavigateBack();
    }
  }

  [RelayCommand]
  public async Task NavigateBack()
  {

  }
}
