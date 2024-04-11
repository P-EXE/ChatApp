using ChatShared.Models;

namespace ChatApp;

public static class Constants
{
  /// <summary>
  /// The base URI for the Datasync service.
  /// </summary>
  public static string ServiceUri = "https://demo-datasync-quickstart.azurewebsites.net";

  /// <summary>
  /// The application (client) ID for the native app within Microsoft Entra ID
  /// </summary>
  public static string ApplicationId = "<client-id>";

  /// <summary>
  /// The list of scopes to request
  /// </summary>
  public static string[] Scopes = new[]
  {
    "<scope>"
  };

  public static string APIConnection = "http://localhost:5225/api/";
  public static BearerToken? BearerToken;

  public static string LocalDBConnection = "Data/ChatApp.db3";
}