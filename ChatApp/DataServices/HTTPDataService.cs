﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace ChatApp.DataServices;

public class HTTPDataService
{
  private readonly HttpClient _httpClient;
  private readonly JsonSerializerOptions _jsonSerializerOptions;

  public HTTPDataService()
  {
    _httpClient = new HttpClient();

    _jsonSerializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
  }

  public async Task<T?> HTTPGet<T>(string route, [CallerMemberName] string caller = "")
  {
    try
    {
      HttpResponseMessage response = await _httpClient.GetAsync(route);
      if (response.IsSuccessStatusCode)
      {
        Debug.WriteLine($"==Success==> {caller} / {nameof(HTTPGet)} : Got {nameof(T)}");
        string responseContent = await response.Content.ReadAsStringAsync();
        T? t = JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
        return t;
      }
      else
      {
        Debug.WriteLine($"==Error==> {caller} / {nameof(HTTPGet)} : could not get {nameof(T)}");
        Debug.WriteLine($"           {response}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"==Exception==> {caller} / {nameof(HTTPGet)} : exception occured while trying to get {nameof(T)}");
      Debug.WriteLine($"               {ex}");
    }
    return default(T?);
  }

  public async Task<T?> HTTPGet<T>(string route, Dictionary<string,string> queriesDict, [CallerMemberName] string caller = "")
  {
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
        Debug.WriteLine($"==Success==> {caller} / {nameof(HTTPGet)} : Got {nameof(T)}");
        string responseContent = await response.Content.ReadAsStringAsync();
        T? t = JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
        return t;
      }
      else
      {
        Debug.WriteLine($"==Error==> {caller} / {nameof(HTTPGet)} : could not get {nameof(T)}");
        Debug.WriteLine($"           {response}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"==Exception==> {caller} / {nameof(HTTPGet)} : exception occured while trying to get {nameof(T)}");
      Debug.WriteLine($"               {ex}");
    }
    return default(T?);
  }
  
  public async Task<T2?> HTTPPost<T1,T2>(string route, T1 t1, [CallerMemberName] string caller = "")
  {
    try
    {
      string json = JsonSerializer.Serialize(t1, _jsonSerializerOptions);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(route, content);
      if (response.IsSuccessStatusCode)
      {
        Debug.WriteLine($"==Success==> {caller} / {nameof(HTTPGet)} : Got {nameof(T2)}");
        string responseContent = await response.Content.ReadAsStringAsync();
        T2? t2 = JsonSerializer.Deserialize<T2>(responseContent, _jsonSerializerOptions);
        return t2;
      }
      else
      {
        Debug.WriteLine($"==Error==> {caller} / {nameof(HTTPGet)} : could not get {nameof(T2)}");
        Debug.WriteLine($"           {response}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"==Exception==> {caller} / {nameof(HTTPGet)} : exception occured while trying to get {nameof(T2)}");
      Debug.WriteLine($"               {ex}");
    }
    return default(T2?);
  }
}
