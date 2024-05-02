using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repos;

public class MessageRepo : IMessageRepo
{

  private readonly SQLDBContext _context;
  private readonly IMapper _mapper;

  public MessageRepo(SQLDBContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task CreateMessageInChatAsync(AppUser user, Guid chatId, Message_DTOCreate createMessage)
  {
    Chat? chat = await _context.Chats.FindAsync(chatId);
    int lastMessageId = _context.Chats
      .Include(c => c.Messages)
      .Where(c => c.Id == chatId).First()
      .Messages
      .Select(m => (int?)m.MessageId).Max() ?? 0;

    Message? message = new()
    {
      ChatId = chat.Id,
      Chat = chat,
      SenderId = user.Id,
      Sender = user,
      MessageId = lastMessageId + 1,
      Text = createMessage.Text
    };

    chat.Messages.Add(message);

    _context.Chats.Update(chat);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteMessageInChatAsync(AppUser user, Guid chatId, int messageId)
  {
    Message? message = _context.Chats
      .Where(c => c.Id == chatId).First()
      .Messages
      .Where(m => m.MessageId == messageId).First();

    _context.Messages.Remove(message);

    await _context.SaveChangesAsync();
  }

  public async Task<IEnumerable<Message_DTORead1>?> GetSomeMessagesInChatAsync(Guid chatId, int position)
  {
    int pageSize = 10;
    IEnumerable<Message>? messages = _context.Chats
      .Include(c => c.Messages)
      .Where(c => c.Id == chatId).First()
      .Messages
      .Skip(pageSize * position)
      .Take(pageSize)
      .AsEnumerable();
    IEnumerable<Message_DTORead1>? messagesDTO = _mapper.Map<IEnumerable<Message>?, IEnumerable<Message_DTORead1>?>(messages);
    return messagesDTO;
  }
}
