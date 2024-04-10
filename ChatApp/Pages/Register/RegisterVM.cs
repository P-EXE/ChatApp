using ChatApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class RegisterVM : ObservableObject
{
  private readonly UserService _userService;
  public RegisterVM(UserService userService)
  {
    _userService = userService;
  }

  [ObservableProperty]
  private string? _email;
  [ObservableProperty]
  private string? _password;

  [RelayCommand]
  public async Task Register()
  {
    bool success = false;
    
    success = await _userService.RegisterAsync(Email, Password);
    if (!success) return;
  }
}
