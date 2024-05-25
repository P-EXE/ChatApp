using AutoMapper;
using ChatShared.Models;

namespace ChatApp.Services;

public class ChatService : IChatService
{
  private readonly IHttpService _httpService;
  private readonly IMapper _mapper;
  public ChatService(IHttpService httpService, IMapper mapper)
  {
    _httpService = httpService;
    _mapper = mapper;
  }

  public async Task<Chat_Read?> CreateChatAsync(Chat_Create createChat)
  {
    return await _httpService.PostAsync<Chat_Create, Chat_Read?>("user/chats", createChat);
  }

  public async Task<List<Chat_Read>?> GetChatsAsync()
  {
    return await _httpService.GetAsync<List<Chat_Read>?>("user/chats");
  }
}
