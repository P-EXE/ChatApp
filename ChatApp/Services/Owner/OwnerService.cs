﻿using ChatApp.DataContexts;
using ChatApp.Models;
using ChatShared.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ChatApp.Services;

public class OwnerService : IOwnerService
{
  private readonly IHttpService _httpService;
  private readonly SQLiteDBContext _sqlitedbContext;
  public OwnerService(IHttpService httpService, SQLiteDBContext sqlitedbContext)
  {
    _httpService = httpService;
    _sqlitedbContext = sqlitedbContext;
  }

  public async Task<bool> RegisterAsync(string email, string password)
  {
    AppUser_Create createUser = new() { Email = email, Password = password };

    bool result = await _httpService.PostAsync("user/register", createUser);
    return result;
  }

  public async Task<bool> LoginAsync(string email, string password)
  {
    AppUser_Create createUser = new() { Email = email, Password = password };

    BearerToken? bt = await _httpService.PostAsync<AppUser_Create, BearerToken>("user/login", createUser);
    if (bt != null)
    {
      Debug.WriteLine($"==Success==> {nameof(LoginAsync)} : Got {nameof(BearerToken)}");

      Statics.BearerToken = bt;
      /*_sqlitedbContext.BearerTokens.Add(bt);*/
      AuthenticationHeaderValue authHeader = new("Bearer", Statics.BearerToken?.AccessToken ?? "");
      await _httpService.InjectAuthHeader(authHeader);
      Statics.AppOwner = await _httpService.GetAsync<AppOwner>("user/self/private");

      /*await _sqlitedbContext.Owner.AddAsync(Statics.AppOwner);*/
      return true;
    }
    return false;
  }

  public async Task<bool> DeleteAsync()
  {
    throw new NotImplementedException();
    return false;
  }

  public async Task<bool> LogoutAsync()
  {
    throw new NotImplementedException();
    return false;
  }

  public async Task<bool> CheckUserLoginStateAsync()
  {
    string? bt = await SecureStorage.Default.GetAsync("AccessToken");
    if (bt != null) return true;
    return false;
  }
}
