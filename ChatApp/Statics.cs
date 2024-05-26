using ChatApp.Models;
using ChatShared.Models;

namespace ChatApp;

public static class Statics
{
#if ANDROID
  public static string RouteBaseHttp = "http://10.0.2.2:5225/api/";
  public static string RouteBaseHttps = "https://localhost:7116/api/";
#elif WINDOWS
  public static string RouteBaseHttp = "http://localhost:5225/api/";
  public static string RouteBaseHttps = "https://localhost:7116/api/";
#else
  public static string RouteBaseHttp = string.Empty;
  public static string RouteBaseHttps = string.Empty;
#endif
  public static string LocalSQLiteConnection = "DataSource=myshareddb;mode=memory;cache=shared";
  public static string DefaultEmail = "user1@mail.com";
  public static string DefaultPassword = "P455w0rd!";
  public static BearerToken? BearerToken { get; set; }
  public static AppOwner? AppOwner { get; set; }
}