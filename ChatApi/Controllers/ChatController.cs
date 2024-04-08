using Microsoft.AspNetCore.Mvc;
using ChatApi.Repos;
using ChatShared.Models;

namespace ChatApi.Controllers;

[Route("api/chats")]
[ApiController]
public class ChatController : ControllerBase
{
  private readonly IChatRepo _chatRepo;
  public ChatController(IChatRepo chatRepo)
  {
    _chatRepo = chatRepo;
  }

  [HttpPost]
  public async Task CreateChat([FromBody] Chat_DTOCreate createChat)
  {
    await _chatRepo.CreateChatAsync(createChat);
  }

  [HttpDelete("{chatId}")]
  public async Task DeleteChat([FromRoute] Guid chatId)
  {
    await _chatRepo.DeleteChatAsync(chatId);
  }

  [HttpPost("{chatId}/users")]
  public async Task AddUserToChat([FromRoute] Guid chatId, [FromBody] Guid userId)
  {
    await _chatRepo.AddUserToChatAsync(chatId, userId);
  }

  [HttpDelete("{chatId}/users")]
  public async Task RemoveUserFromChat([FromRoute] Guid chatId, [FromBody] Guid userId)
  {
    await _chatRepo.RemoveUserFromChatAsync(chatId, userId);
  }
}
