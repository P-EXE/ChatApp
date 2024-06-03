using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

  public async Task<Chat_Read?> CreateChatAsync(Chat_Create createChat)
  {
    Chat chat;
    AppUser? user;

    // Create the Chat and Save it
    chat = _mapper.Map<Chat_Create, Chat>(createChat);
    await _context.Chats.AddAsync(chat);

    // Find all affected Users
    foreach (Guid userId in createChat.UserIds)
    {
      user = await _context.Users.FindAsync(userId);
      if (user != null)
      {
        chat.Users.Add(user);
      }
    }

    // Save the Chat and return it
    await _context.SaveChangesAsync();
    return _mapper.Map<Chat_Read>(chat);
  }

  public async Task<Chat_Read?> ReadChatAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public async Task<Chat_Read?> UpdateChatAsync(Chat_Update updateChat)
  {
    Chat? chat;
    AppUser? user;
    List<AppUser> oldUsers = new();
    List<AppUser> newUsers = new();

    // Find the Chat and update it
    chat = await _context.Chats
      .Include(c => c.Users)
      .FirstAsync(c => c.Id == updateChat.Id);
    chat.Name = updateChat.Name;
    chat.Description = updateChat.Description;

    // Set old and new Users
    oldUsers = chat.Users.ToList();
    foreach (Guid newUsereId in updateChat.UserIds)
    {
      newUsers.Add(await _context.Users.FindAsync(newUsereId));
    }

    // Remove old Users
    foreach (AppUser oldUser in oldUsers)
    {
      if (!newUsers.Contains(oldUser))
      {
        chat.Users.Remove(oldUser);
      }
    }

    // Add new Users
    foreach (AppUser newUser in newUsers)
    {
      if (!oldUsers.Contains(newUser))
      {
        chat.Users.Add(newUser);
      }
    }

    // Save the Chat and return it
    await _context.SaveChangesAsync();
    return _mapper.Map<Chat_Read>(chat);
  }

  public async Task<bool> DeleteChatAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<Chat>?> ReadAllChatsAsync()
  {
    throw new NotImplementedException();
  }
}
