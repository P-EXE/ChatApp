﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace ChatApp.Services;

internal class HttpService : IHttpService
{
  private readonly HttpClient _httpClient;
  private readonly JsonSerializerOptions _jsonSerializerOptions;
  public HttpService(HttpClient httpClient)
  {
    _httpClient = httpClient;

    _jsonSerializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
  }

  public async Task<T?> GetAsync<T>(string route, [CallerMemberName] string caller = "")
  {
    T? t = default(T);
    try
    {
      HttpResponseMessage response = await _httpClient.GetAsync(route);
      if (response.IsSuccessStatusCode)
      {
        Debug.WriteLine($"==Success==> {caller} / {nameof(GetAsync)} : Got {t.GetType}");
        string responseContent = await response.Content.ReadAsStringAsync();
        t = JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
        return t;
      }
      else
      {
        Debug.WriteLine($"==Error==> {caller} / {nameof(GetAsync)} : could not get {t.GetType}");
        Debug.WriteLine($"           {response}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"==Exception==> {caller} / {nameof(GetAsync)} : exception occured while trying to get {t.GetType}");
      Debug.WriteLine($"               {ex}");
    }
    return t;
  }

  public async Task<T?> GetAsync<T>(string route, Dictionary<string, string> queriesDict, [CallerMemberName] string caller = "")
  {
    T? t = default(T);
    string queries = "?";
    for (int i = 0; i < queriesDict.Count - 1; i++)
    {
      queries += $"{queriesDict.ElementAt(i).Key}={queriesDict.ElementAt(i).Value}&";
    }
    queries += $"{queriesDict.Last().Key}={queriesDict.Last().Value}";

    try
    {
      HttpResponseMessage response = await _httpClient.GetAsync(route + queries);
      if (response.IsSuccessStatusCode)
      {
        Debug.WriteLine($"==Success==> {caller} / {nameof(GetAsync)} : Got {t.GetType}");
        string responseContent = await response.Content.ReadAsStringAsync();
        t = JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
        return t;
      }
      else
      {
        Debug.WriteLine($"==Error==> {caller} / {nameof(GetAsync)} : could not get {t.GetType}");
        Debug.WriteLine($"           {response}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"==Exception==> {caller} / {nameof(GetAsync)} : exception occured while trying to get {t.GetType}");
      Debug.WriteLine($"               {ex}");
    }
    return t;
  }

  public async Task<HttpResponseMessage?> FullPostAsync<T>(string route, T t, [CallerMemberName] string caller = "")
  {
    try
    {
      string json = JsonSerializer.Serialize(t, _jsonSerializerOptions);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(route, content);
      if (response.IsSuccessStatusCode)
      {
        Debug.WriteLine($"==Success==> {caller} / {nameof(PostAsync)} : {response.StatusCode}");
        return response;
      }
      else
      {
        Debug.WriteLine($"==Error==> {caller} / {nameof(PostAsync)} : {response.StatusCode}");
        Debug.WriteLine($"           {response}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"==Exception==> {caller} / {nameof(PostAsync)} : exception occured while trying to post {t.GetType}");
      Debug.WriteLine($"               {ex}");
    }
    return null;
  }

  public async Task<bool> PostAsync<T>(string route, T t, [CallerMemberName] string caller = "")
  {
    try
    {
      string json = JsonSerializer.Serialize(t, _jsonSerializerOptions);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(route, content);
      if (response.IsSuccessStatusCode)
      {
        Debug.WriteLine($"==Success==> {caller} / {nameof(PostAsync)} : {response.StatusCode}");
        return true;
      }
      else
      {
        Debug.WriteLine($"==Error==> {caller} / {nameof(PostAsync)} : {response.StatusCode}");
        Debug.WriteLine($"           {response}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"==Exception==> {caller} / {nameof(PostAsync)} : exception occured while trying to post {t.GetType}");
      Debug.WriteLine($"               {ex}");
    }
    return false;
  }

  public async Task<T2?> PostAsync<T1, T2>(string route, T1 t1, [CallerMemberName] string caller = "")
  {
    try
    {
      string json = JsonSerializer.Serialize(t1, _jsonSerializerOptions);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(route, content);
      if (response.IsSuccessStatusCode)
      {
        Debug.WriteLine($"==Success==> {caller} / {nameof(PostAsync)} : Posted {nameof(T1)}, got back {nameof(T2)}");
        string responseContent = await response.Content.ReadAsStringAsync();
        T2? t2 = JsonSerializer.Deserialize<T2>(responseContent, _jsonSerializerOptions);
        return t2;
      }
      else
      {
        Debug.WriteLine($"==Error==> {caller} / {nameof(PostAsync)} : Posted {nameof(T1)}, could not get back {nameof(T2)}");
        Debug.WriteLine($"           {response}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"==Exception==> {caller} / {nameof(PostAsync)} : Exception occured while trying to post {nameof(T1)}");
      Debug.WriteLine($"               {ex}");
    }
    return default(T2?);
  }
}