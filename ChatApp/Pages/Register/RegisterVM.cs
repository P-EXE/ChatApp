using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class RegisterVM : ObservableObject
{
  public RegisterVM()
  {
  }

  [ObservableProperty]
  private string? _email;
  [ObservableProperty]
  private string? _password;

  [RelayCommand]
  public async Task Register()
  {
    bool success = false;
  }
}
