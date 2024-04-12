﻿using ChatApp.Pages;

namespace ChatApp;

public partial class AppShell : Shell
{
  public AppShell()
  {
    InitializeComponent();

    Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
    Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

    Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

    Routing.RegisterRoute(nameof(ChatsPage), typeof(ChatsPage));
    Routing.RegisterRoute(nameof(NewChatPage), typeof(NewChatPage));

    Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
    Routing.RegisterRoute(nameof(NewContactPage), typeof(NewContactPage));
  }
}
