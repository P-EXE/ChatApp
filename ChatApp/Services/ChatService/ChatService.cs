using AutoMapper;
using ChatShared.Models;
using System.Collections.ObjectModel;

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

  public async Task<Chat_MAUI?> CreateChatAsync(Chat_MAUI chat)
  {
    /*Chat_Create createChat = _mapper.Map<Chat_MAUI,Chat_Create>(chat);*/
    Chat_Create createChat = new()
    {
      Name = chat.Name,
      Description = chat.Description
    };

    foreach (AppUser user in chat.Users)
    {
      createChat.UserIds.Add(user.Id);
    }

    Chat_Read? readChat = await _httpService.PostAsync<Chat_Create, Chat_Read?>("chat", createChat);
    return _mapper.Map<Chat_MAUI>(readChat);
  }

  public async Task<Chat_MAUI?> UpdateChatAsync(Chat_MAUI chat)
  {
    Chat_Update updateChat = new()
    {
      Id = chat.Id,
      Name = chat.Name,
      Description = chat.Description
    };

    foreach (AppUser user in chat.Users)
    {
      updateChat.UserIds.Add(user.Id);
    }

    Chat_Read? readChat = await _httpService.PutAsync<Chat_Update, Chat_Read?>("chat", updateChat);
    return null;
  }

  public async Task<IEnumerable<Chat_MAUI>?> GetChatsAsync()
  {
    IEnumerable<Chat_Read>? chatsRead = await _httpService.GetAsync<IEnumerable<Chat_Read>?>("user/chats");
    // Does not work
    /*IEnumerable<Chat_MAUI>? retChats = _mapper.Map<IEnumerable<Chat_Read>, IEnumerable<Chat_MAUI>>(chats);*/
    // Manual version
    List<Chat_MAUI>? chats = [];
    foreach (Chat_Read readChat in chatsRead)
    {
      Chat_MAUI chat = new()
      {
        Id = readChat.Id,
        Name = readChat.Name,
        Description = readChat.Description,
        Users = new(readChat.Users),
        Messages = new(readChat.Messages)
      };
      chats.Add(chat);
    }

    return chats;
  }
}
