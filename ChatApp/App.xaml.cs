using ChatApp.Pages;
using ChatApp.Services.Auth;

namespace ChatApp;

public partial class App : Application
{
  public App(IAuthService authService)
  {
    InitializeComponent();

    MainPage = new AppShell();

    bool allowAccess = authService.CheckUserLoginStateAsync().Result;
    if (allowAccess)
    {
      Shell.Current.GoToAsync($"//{nameof(ChatsPage)}");
      return;
    }
  }
}
