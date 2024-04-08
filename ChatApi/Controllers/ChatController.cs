using AutoMapper;
using ChatApi.DataContexts;
using ChatApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers;

[Route("api/chats")]
[ApiController]
public class ChatController : ControllerBase
{
  private readonly SQLDBContext _sqldbContext;
  private readonly IMapper _mapper;

  public ChatController(SQLDBContext sqldbContext, IMapper mapper)
  {
    _sqldbContext = sqldbContext;
    _mapper = mapper;
  }

  [HttpPost]
  public async Task CreateChat([FromBody] Chat_DTOCreate createChat)
  {
    Chat? chat = _mapper.Map<Chat_DTOCreate, Chat>(createChat);
    _sqldbContext.Chats.Add(chat);

    await _sqldbContext.SaveChangesAsync();
  }

  [HttpDelete("{chatId}")]
  public async Task DeleteChat([FromRoute] Guid chatId)
  {
    Chat? chat = await _sqldbContext.Chats.FindAsync(chatId);

    _sqldbContext.Chats.Remove(chat);

    await _sqldbContext.SaveChangesAsync();
  }

  [HttpPost("{chatId}/users")]
  public async Task AddUserToChat([FromRoute] Guid chatId, [FromBody] Guid userId)
  {
    Chat? chat = await _sqldbContext.Chats.FindAsync(chatId);
    User? user = await _sqldbContext.Users.FindAsync(userId);

    chat.Users.Add(user);

    _sqldbContext.Chats.Update(chat);
    _sqldbContext.Users.Update(user);

    await _sqldbContext.SaveChangesAsync();
  }

  [HttpDelete("{chatId}/users")]
  public async Task RemoveUserFromChat([FromRoute] Guid chatId, [FromBody] Guid userId)
  {
    Chat? chat = await _sqldbContext.Chats.FindAsync(chatId);
    User? user = await _sqldbContext.Users.FindAsync(userId);

    chat.Users.Remove(user);

    _sqldbContext.Update(chat);
    _sqldbContext.Update(user);

    await _sqldbContext.SaveChangesAsync();
  }
}
