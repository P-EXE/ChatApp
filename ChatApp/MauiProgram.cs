using ChatApp.DataContexts;
using ChatApp.Pages;
using ChatApp.Services;
using ChatApp.ViewModels;
using ChatApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace ChatApp;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .UseMauiCommunityToolkit()
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    #region Services
    builder.Services.AddTransient<IOwnerService, OwnerService>();
    builder.Services.AddTransient<IContactService, ContactService>();
    builder.Services.AddTransient<IChatService, ChatService>();
    builder.Services.AddTransient<IHttpService, HttpService>();
    builder.Services.AddHttpClient<IHttpService, HttpService>(client =>
    {
      client.BaseAddress = new Uri(Statics.RouteBaseHttp);
      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Statics.BearerToken?.AccessToken ?? "");
    });
    #endregion Services

    #region SQLiteDBContext
    SqliteConnection sqliteConnection = new(Statics.LocalSQLiteConnection);
    sqliteConnection.Open();
    builder.Services.AddDbContext<SQLiteDBContext>(options =>
      options.UseSqlite(sqliteConnection)
    );
    #endregion SQLiteDBContext

    #region Pages Views Viewmodels
    builder.Services.AddTransient<AppShell>();

    builder.Services.AddTransient<RegisterPage>();
    builder.Services.AddTransient<RegisterVM>();

    builder.Services.AddTransient<LoginPage>();
    builder.Services.AddTransient<LoginVM>();

    builder.Services.AddTransient<ChatsPage>();
    builder.Services.AddTransient<ChatsVM>();
    builder.Services.AddTransient<ChatListV>();

    builder.Services.AddTransient<ChatPage>();
    builder.Services.AddTransient<ChatVM>();
    builder.Services.AddTransient<ChatDetailsPage>();
    builder.Services.AddTransient<ChatDetailsVM>();

    builder.Services.AddTransient<NewChatPage>();
    builder.Services.AddTransient<NewChatVM>();

    builder.Services.AddTransient<ContactsPage>();
    builder.Services.AddTransient<ContactsVM>();
    builder.Services.AddTransient<ContactV>();

    builder.Services.AddTransient<UserProfilePage>();
    builder.Services.AddTransient<UserProfileVM>();

    builder.Services.AddTransient<NewContactPage>();
    builder.Services.AddTransient<NewContactVM>();
    #endregion Pages Views Viewmodels

#if DEBUG
    builder.Logging.AddDebug();
#endif

    return builder.Build();
  }
}
