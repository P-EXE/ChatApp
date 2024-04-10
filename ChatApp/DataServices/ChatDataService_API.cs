using ChatShared.Models;
using System.Text.Json;

namespace ChatApp.DataServices;

public class ChatDataService_API
{
  private readonly HTTPDataService _http;
  private readonly string _baseAddress;

  public ChatDataService_API()
  {
    _baseAddress = $"https://localhost:7014/api";
  }

  public async Task<IEnumerable<Chat>?> GetChatsByMemberUser(string userId)
  {
    IEnumerable<Chat>? chats = await _http.HTTPGet<IEnumerable<Chat>>(_baseAddress + $"/users/{userId}/chats");
    return chats;
  }
}