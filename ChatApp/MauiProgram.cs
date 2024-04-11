using ChatApp.DataContexts;
using ChatApp.Flows;
using ChatApp.Pages;
using ChatApp.Services;
using ChatApp.Services.Auth;
using ChatApp.ViewModels;
using ChatApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

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

    #region Services
    builder.Services.AddTransient<IAuthService, CustomAuthService>();
    builder.Services.AddTransient<IHttpService, HttpService>();
    builder.Services.AddHttpClient("DefaultClient", client =>
    {
      client.BaseAddress = new Uri(Constants.APIConnection);
    });
    builder.Services.AddHttpClient("AuthedClient", client =>
    {
      client.BaseAddress = new Uri(Constants.APIConnection);
    });
    #endregion Services

    #region SQLiteDBContext
    string SQLitePath = Path.Combine(
      FileSystem.AppDataDirectory,
      Constants.LocalDBConnection
    );

    builder.Services.AddDbContext<SQLiteDBContext>(options =>
      options.UseSqlite(SQLitePath)
    );
    #endregion SQLiteDBContext

    #region Models
    #endregion Models

    #region Flows
    builder.Services.AddTransient<FirstTimeFlow>();
    #endregion Flows

    #region Pages Views Viewmodels
    builder.Services.AddTransient<AppShell>();

    builder.Services.AddTransient<RegisterPage>();
    builder.Services.AddTransient<RegisterVM>();

    builder.Services.AddTransient<LoginPage>();
    builder.Services.AddTransient<LoginVM>();

    builder.Services.AddTransient<ChatsPage>();
    builder.Services.AddTransient<ChatsVM>();
    builder.Services.AddTransient<ChatV>();
    #endregion Pages Views Viewmodels

#if DEBUG
    builder.Logging.AddDebug();
#endif

    return builder.Build();
  }
}
