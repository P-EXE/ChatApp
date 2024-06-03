using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace ChatApp.Services;

public interface IHttpService
{
  Task InjectAuthHeader(AuthenticationHeaderValue authHeader);
  Task<T?> GetAsync<T>(string route, [CallerMemberName] string caller = "");
  Task<T?> GetAsync<T>(string route, Dictionary<string, string> queriesDict, [CallerMemberName] string caller = "");

  Task<bool> PostAsync<T>(string route, T t, [CallerMemberName] string caller = "");
  Task<HttpResponseMessage?> FullPostAsync<T>(string route, T t, [CallerMemberName] string caller = "");
  Task<T2?> PostAsync<T1, T2>(string route, T1 input, [CallerMemberName] string caller = "");

  Task<T2?> PutAsync<T1, T2>(string route, T1 input, [CallerMemberName] string caller = "");
}
