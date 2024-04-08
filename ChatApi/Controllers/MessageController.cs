using AutoMapper;
using ChatApi.DataContexts;
using ChatApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Controllers
{
  [Route("api/chats/{chatId}/messages")]
  [ApiController]
  public class MessageController : ControllerBase
  {
    private readonly SQLDBContext _sqldbContext;
    private readonly IMapper _mapper;

    public MessageController(SQLDBContext sqldbContext, IMapper mapper)
    {
      _sqldbContext = sqldbContext;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task CreateMessageInChat([FromRoute] Guid chatId, [FromBody] Message_DTOCreate createMessage)
    {
      Chat? chat = await _sqldbContext.Chats.FindAsync(chatId);
      Message? message = _mapper.Map<Message_DTOCreate, Message>(createMessage);

      chat.Messages.Add(message);

      _sqldbContext.Chats.Update(chat);
      await _sqldbContext.SaveChangesAsync();
    }

    [HttpDelete("{messageId}")]
    public async Task DeleteMessageInChat([FromRoute] Guid chatId, [FromRoute] int messageId)
    {
      Message? message = _sqldbContext.Chats
        .Include(c => c.Messages)
        .Where(c => c.Id == chatId).First()
        .Messages
        .Where(m => m.MessageId == messageId).First();
      
      _sqldbContext.Messages.Remove(message);

      await _sqldbContext.SaveChangesAsync();
    }
  }
}
