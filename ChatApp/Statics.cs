﻿using ChatShared.Models;

namespace ChatApp;

public static class Statics
{
  public static string RouteBaseHttp = "http://localhost:5225/api/";
  public static string RouteBaseHttps = "https://localhost:7116/api/";
  public static string LocalSQLiteConnection = "DataSource=myshareddb;mode=memory;cache=shared";
  public static string DefaultEmail = "user1@mail.com";
  public static string DefaultPassword = "P455w0rd!";
  public static BearerToken? BearerToken { get; set; }
}