using Auth0.OidcClient;
using ChatApp.DataContexts;
using ChatApp.DataServices;
using ChatApp.Flows;
using ChatApp.Models;
using ChatApp.Pages;
using ChatApp.Services;
using ChatApp.ViewModels;
using ChatApp.Views;
using IdentityModel.OidcClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

    #region Auth
/*    builder.Services.AddTransient<OidcClient>(sp =>
      new OidcClient(
        new OidcClientOptions
        {
          Authority = "https://localhost:7014",
          ClientId = "ChatApp.AppClient",
          Scope = "",
          RedirectUri = "",
          PostLogoutRedirectUri = "",
          ClientSecret = "",
          HttpClientFactory = options => sp.GetRequiredService<HttpClient>()
        }
      )
    );*/
    #endregion Auth

    #region SQLiteDBContext
    string SQLitePath = Path.Combine(
      FileSystem.AppDataDirectory,
      builder.Configuration.GetConnectionString("ChatApp-SQLiteConnection") ?? ""
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

    #region Services
    builder.Services.AddSingleton<HTTPDataService>();
    builder.Services.AddSingleton<UserDataService_Local>();
    builder.Services.AddSingleton<UserDataService_API>();
    builder.Services.AddSingleton<UserService>();

    builder.Services.AddSingleton<ChatService>();
    #endregion Services

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
