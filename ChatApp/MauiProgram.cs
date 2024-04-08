using ChatApp.DataServices;
using ChatApp.Pages;
using ChatApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace ChatApp;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    builder.Services.AddSingleton<ChatsPage>();
    builder.Services.AddSingleton<ChatsVM>();
    builder.Services.AddSingleton<ContactsPage>();
    builder.Services.AddSingleton<ContactsVM>();
    builder.Services.AddSingleton<SettingsPage>();
    builder.Services.AddSingleton<SettingsVM>();

    builder.Services.AddSingleton<RegisterPage>();
    builder.Services.AddSingleton<RegisterVM>();

    builder.Services.AddSingleton<IUserDataService, UserDataService_API>();
    builder.Services.AddSingleton<IChatDataService, ChatDataService_API>();
    builder.Services.AddSingleton<IMessageDataService, MessageDataService_API>();

#if DEBUG
    builder.Logging.AddDebug();
#endif

    return builder.Build();
  }
}
