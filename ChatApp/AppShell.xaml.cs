using ChatApp.Pages;

namespace ChatApp
{
  public partial class AppShell : Shell
  {
    public AppShell()
    {
      InitializeComponent();

      Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
      Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

      Routing.RegisterRoute(nameof(Chats), typeof(Chats));

      Routing.RegisterRoute(nameof(ChatsPage), typeof(ChatsPage));
    }
  }
}
