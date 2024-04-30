using AutoMapper;
using ChatApi.DataContexts;
using ChatApi.Models;
using ChatShared.Models;

namespace ChatApi.Repos;

public class ChatRepo : IChatRepo
{

  private readonly SQLDBContext _context;
  private readonly IMapper _mapper;

  public ChatRepo(SQLDBContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<Guid?> CreateChatAsync(AppUser user, Chat_DTOCreate createChat)
  {
    Chat? chat = _mapper.Map<Chat_DTOCreate, Chat>(createChat);
    chat.Users.Add(user);
    _context.Chats.Add(chat);
    await _context.SaveChangesAsync();
    return chat.Id;
  }

  public async Task DeleteChatAsync(Guid chatId)
  {
    Chat? chat = await _context.Chats.FindAsync(chatId);

    _context.Chats.Remove(chat);

    await _context.SaveChangesAsync();
  }

  public async Task AddUserToChatAsync(Guid chatId, Guid userId)
  {
    Chat? chat = await _context.Chats.FindAsync(chatId);
    AppUser? user = await _context.Users.FindAsync(userId);

    chat.Users.Add(user);

    _context.Chats.Update(chat);
    _context.Users.Update(user);

    await _context.SaveChangesAsync();
  }

  public async Task RemoveUserFromChatAsync(Guid chatId, Guid userId)
  {
    Chat? chat = await _context.Chats.FindAsync(chatId);
    AppUser? user = await _context.Users.FindAsync(userId);

    chat.Users.Remove(user);

    _context.Update(chat);
    _context.Update(user);

    await _context.SaveChangesAsync();
  }
}
