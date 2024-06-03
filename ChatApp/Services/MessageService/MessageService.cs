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

  public async Task<IEnumerable<Message>?> GetMessagesOfChatAsync(string chatId, int position)
  {
    IEnumerable<Message>? readMessages = await _httpService.GetAsync<IEnumerable<Message>>($"chat/messages?chatId={chatId}&position={position}");
    return readMessages;
  }

  public async Task<Message?> SendMessageToChatAsync(Message message)
  {
    Message_Create createMessage = new()
    {
      ChatId = message.Chat.Id,
      Text = message.Text,
      UserId = Statics.AppOwner.Id
    };

    Message? retMessage = await _httpService.PostAsync<Message_Create, Message>($"chat/messages", createMessage);
    return retMessage;
  }
}
