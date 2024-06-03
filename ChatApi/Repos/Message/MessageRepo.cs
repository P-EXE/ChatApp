using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repos;

public class MessageRepo : IMessageRepo
{

  private readonly SQLDBContext _context;
  private readonly IMapper _mapper;

  private const int takeSize = 20;

  public MessageRepo(SQLDBContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<Message_Read?> CreateMessageInChatAsync(Message_Create createMessage)
  {
    Message message = _mapper.Map<Message>(createMessage);

    Chat chat = await _context.Chats
      .Include(c => c.Messages).Include(c => c.Users)
      .FirstAsync(c => c.Id == createMessage.ChatId);

    message.User = await _context.Users.FindAsync(createMessage.UserId);
    message.Chat = chat;

    chat.Messages.Add(message);
    _context.SaveChanges();
    return _mapper.Map<Message, Message_Read>(message);
  }

  public async Task<IEnumerable<Message_Read>?> GetSomeMessagesInChatAsync(Guid chatId, int position)
  {
    IEnumerable<Message> messages = _context.Chats
      .Include(c => c.Messages)
      .Where(c => c.Id == chatId)
      .First()
      .Messages
      .Skip(takeSize * position)
      .Take(takeSize)
      .AsEnumerable();

    return _mapper.Map<IEnumerable<Message_Read>>(messages);
  }
}
