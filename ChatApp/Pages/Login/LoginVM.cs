using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class LoginVM : ObservableObject
{
  public LoginVM()
  {
  }

  [ObservableProperty]
  private string _email;
  [ObservableProperty]
  private string _password;

  [RelayCommand]
  public async Task<bool> SignIn()
  {
    return false;
  }
}