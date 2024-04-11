using ChatApp.Pages;
using ChatApp.Services.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class RegisterVM : ObservableObject
{
  private readonly IAuthService _authService;
  private readonly LoginPage _loginPage;
  public RegisterVM(IAuthService authService, LoginPage loginPage)
  {
    _authService = authService;
    _loginPage = loginPage;
  }

  [ObservableProperty]
  private string? _email;
  [ObservableProperty]
  private string? _password;

  [RelayCommand]
  public async Task Register()
  {
    bool result = await _authService.RegisterAsync(Email, Password);
    if (result)
    {
      await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
      return;
    }
    await Shell.Current.DisplayAlert("Error", "Could not register.", "Close");
    return;
  }
}
