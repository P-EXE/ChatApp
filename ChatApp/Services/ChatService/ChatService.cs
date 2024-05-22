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

  public async Task<Guid?> CreateChatAsync(Chat_DTOCreate createChat)
  {
    return await _httpService.PostAsync<Chat_DTOCreate, Guid?>("user/chats", createChat);
  }

  public async Task<Guid?> CreateChatAsync(Chat createChat)
  {
    Chat_DTOCreate chat = _mapper.Map<Chat, Chat_DTOCreate>(createChat);
    return await CreateChatAsync(chat);
  }

  public async Task<IEnumerable<Chat_DTORead>?> GetChatsAsync()
  {
    return await _httpService.GetAsync<IEnumerable<Chat_DTORead>?>("user/chats");
  }
}
