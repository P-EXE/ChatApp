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
      Routing.RegisterRoute($"{nameof(ChatsPage)}/{nameof(ChatDetailsPage)}", typeof(ChatDetailsPage));
      Routing.RegisterRoute($"{nameof(ChatDetailsPage)}/{nameof(UserSearchPage)}", typeof(UserSearchPage));

      Routing.RegisterRoute($"{nameof(ContactsPage)}/{nameof(UserSearchPage)}", typeof(UserSearchPage));
      Routing.RegisterRoute($"{nameof(ContactsPage)}/{nameof(UserSearchPage)}/{nameof(UserProfilePage)}", typeof(UserProfilePage));
    }
  }
}
