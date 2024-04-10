using ChatApp.DataServices;
using ChatApp.Models;
using ChatShared.Models;

namespace ChatApp.Services;

public class ChatService
{
  private readonly AppOwner _owner;
  private readonly ChatDataService_Local _loc;
  private readonly ChatDataService_API _api;
  public ChatService(ChatDataService_Local loc, ChatDataService_API api, AppOwner owner)
  {
    _loc = loc;
    _api = api;
    _owner = owner;
  }

  public async Task<IEnumerable<Chat>?> GetChats()
  {
    List<Chat>? chats = new();
    //Ask ChatDataService_Local
    //Ask ChatDataService_API
    chats.AddRange(await _api.GetChatsByMemberUser(_owner.Id.ToString()));
    return chats;
  }
}
