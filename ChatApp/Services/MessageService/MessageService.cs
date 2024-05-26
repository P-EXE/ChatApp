using AutoMapper;
using ChatShared.Models;

namespace ChatApp.Services;

public class MessageService : IMessageService
{
  private readonly IHttpService _httpService;
  private readonly IMapper _mapper;
  public MessageService(IHttpService httpService, IMapper mapper)
  {
    _httpService = httpService;
    _mapper = mapper;
  }

  public async Task<IEnumerable<Message_MAUI>?> GetMessagesOfChatAsync(string chatId, int position)
  {
    IEnumerable<Message_Read>? readMessages = await _httpService.GetAsync<IEnumerable<Message_Read>>($"user/chats/{chatId}/messages?position={position}");
    return _mapper.Map<IEnumerable<Message_MAUI>>(readMessages);
  }

  public async Task<Message_MAUI?> SendMessageToChatAsync(Message_MAUI message)
  {
    Message_Create createMessage = new()
    {
      ChatId = message.Chat.Id,
      Text = message.Text,
      UserId = Statics.AppOwner.Id
    };

    Message_Read? readMessage = await _httpService.PostAsync<Message_Create, Message_Read>($"chat/messages", createMessage);
    return _mapper.Map<Message_MAUI>(readMessage);
  }
}
