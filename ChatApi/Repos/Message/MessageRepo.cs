using AutoMapper;
using ChatApi.DataContexts;
using ChatApi.Models;

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

  public async Task CreateMessageInChatAsync(Guid chatId, Message_DTOCreate createMessage)
  {
    Chat? chat = await _context.Chats.FindAsync(chatId);
    Message? message = _mapper.Map<Message_DTOCreate, Message>(createMessage);

    chat.Messages.Add(message);

    _context.Chats.Update(chat);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteMessageInChatAsync(Guid chatId, int messageId)
  {
    Message? message = _context.Chats
      .Where(c => c.Id == chatId).First()
      .Messages
      .Where(m => m.MessageId == messageId).First();

    _context.Messages.Remove(message);

    await _context.SaveChangesAsync();
  }
}
