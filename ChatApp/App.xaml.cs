using ChatApp.DataServices;
using ChatApp.Pages;
using ChatApp.ViewModels;

namespace ChatApp;

public partial class App : Application
{
  public App()
  {
    InitializeComponent();

    MainPage = new AppShell();
  }
}
