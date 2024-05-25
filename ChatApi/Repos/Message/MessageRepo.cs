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

  public async Task<Message_Read?> CreateMessageInChatAsync(Message_Create createMessage)
  {
    Message message = _mapper.Map<Message>(createMessage);
    Chat chat = await _context.Chats
      .Include(c => c.Messages).Include(c => c.Users)
      .FirstAsync(c => c.Id == message.ChatId);
    
    chat.Messages.Add(message);
    _context.SaveChanges();
    return _mapper.Map<Message, Message_Read>(message);
  }

  public Task DeleteMessageInChatAsync(AppUser user, Guid chatId, int messageId)
  {
    throw new NotImplementedException();
  }
}
