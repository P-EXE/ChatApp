using ChatApp.Pages;
using ChatApp.Services.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class LoginVM : ObservableObject
{
  private readonly IAuthService _authService;
  public LoginVM(IAuthService authService)
  {
    _authService = authService;
  }

  [ObservableProperty]
  private string _email;
  [ObservableProperty]
  private string _password;

  [RelayCommand]
  public async Task Login()
  {
    bool result = await _authService.LoginAsync(Email, Password);
    if (result)
    {
      await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
      return;
    }
    await Shell.Current.DisplayAlert("Error", "Could not log in.", "Close");
    return;
  }
}