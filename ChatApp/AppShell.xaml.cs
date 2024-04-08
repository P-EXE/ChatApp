using ChatApp.DataServices;
using ChatApp.Pages;
using ChatApp.ViewModels;

namespace ChatApp;

public partial class AppShell : Shell
{
  public AppShell()
  {
    InitializeComponent();

    Routing.RegisterRoute(nameof(ChatsPage), typeof(ChatsPage));
    Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
    Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
    Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
  }
}
