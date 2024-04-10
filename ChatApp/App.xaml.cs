using ChatApp.Flows;

namespace ChatApp;

public partial class App : Application
{
  public App(FirstTimeFlow firstTimeFlow)
  {
    InitializeComponent();

    MainPage = new MainPage();

    firstTimeFlow.FirstTimeSetup();
  }
}
