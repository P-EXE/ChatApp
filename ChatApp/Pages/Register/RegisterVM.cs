using ChatApp.Pages;
using ChatApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class RegisterVM : ObservableObject
{
  private readonly IOwnerService _authService;
  private readonly LoginPage _loginPage;
  public RegisterVM(IOwnerService authService, LoginPage loginPage)
  {
    _authService = authService;
    _loginPage = loginPage;
  }

  [ObservableProperty]
  private string? _email = Statics.DefaultEmail;
  [ObservableProperty]
  private string? _password = Statics.DefaultPassword;

  [RelayCommand]
  public async Task Register()
  {
    bool result = false;
    result = await _authService.RegisterAsync(Email, Password);
    if (!result)
    {
      await Shell.Current.DisplayAlert("Error", "Could not register.", "Close");
      return;
    }
    result = await _authService.LoginAsync(Email, Password);
    if (!result)
    {
      await Shell.Current.DisplayAlert("Error", "Could not log in.", "Close");
      return;
    }
    await Shell.Current.GoToAsync($"//{nameof(ChatsPage)}");
    return;
  }
}
