using ChatApp.Pages;

namespace ChatApp.Flows;

public class FirstTimeFlow
{
  private readonly RegisterPage _registerPage;

  public FirstTimeFlow(RegisterPage registerPage)
  {
    _registerPage = registerPage;
  }

  public void FirstTimeSetup()
  {
    if (false)
    {
      App.Current.MainPage = new AppShell();
      return;
    }

    App.Current.MainPage = _registerPage;
    return;
  }
}
