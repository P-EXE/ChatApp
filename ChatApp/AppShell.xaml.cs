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

      Routing.RegisterRoute($"{nameof(ChatsPage)}/{nameof(ChatPage)}", typeof(ChatPage));
      Routing.RegisterRoute(nameof(NewChatPage), typeof(NewChatPage));

      Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
      Routing.RegisterRoute(nameof(NewContactPage), typeof(NewContactPage));

      Routing.RegisterRoute(nameof(UserProfilePage), typeof(UserProfilePage));
    }
  }
}
