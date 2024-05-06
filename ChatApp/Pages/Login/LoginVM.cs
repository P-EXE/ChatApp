using ChatApp.Pages;
using ChatApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class LoginVM : ObservableObject
{
  private readonly IOwnerService _authService;
  public LoginVM(IOwnerService authService)
  {
    _authService = authService;
  }

  [ObservableProperty]
  private string? _email = Statics.DefaultEmail;
  [ObservableProperty]
  private string? _password = Statics.DefaultPassword;

  [RelayCommand]
  public async Task Login()
  {
    bool result = await _authService.LoginAsync(Email, Password);
    if (result)
    {
      await Shell.Current.GoToAsync($"//{nameof(ChatsPage)}");
      return;
    }
    await Shell.Current.DisplayAlert("Error", "Could not log in.", "Close");
    return;
  }
}