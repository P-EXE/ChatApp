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

  /// Creates a Chat, adds Chat to affected Users, returns created Chat
  public async Task<Chat_Read?> CreateChatAsync(Chat_Create createChat)
  {
    Chat chat = _mapper.Map<Chat>(createChat);

    _context.Chats.Add(chat);

    foreach (Guid userId in createChat.UserIds)
    {
      AppUser? foundUser = await _context.Users.FindAsync(userId);
      foundUser?.Chats.Add(chat);
      try
      {
        _context.Users.Update(foundUser);
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"==EXCEPTION==> {nameof(ChatRepo)} / {nameof(CreateChatAsync)} : User could not be updated!");
        return null;
      }
    }

    _context.SaveChanges();
    Chat? createdChat = await _context.Chats.FindAsync(chat.Id);
    Chat_Read returnChat = _mapper.Map<Chat_Read>(createdChat);

    return returnChat;
  }

  public async Task<Chat_Read?> ReadChatAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public async Task<Chat_Read?> UpdateChatAsync(Chat_Edit updateChat)
  {
    Chat? chat = await _context.Chats
      .Include(c => c.Users)
      .Where(c => c.Id == updateChat.Id)
      .FirstAsync();

    List<AppUser> oldUsers = chat.Users.ToList();
    // Remove removed users
    foreach (AppUser user in oldUsers)
    {
      if (!updateChat.UserIds.Contains(user.Id))
      {
        chat.Users.Remove(user);
        _context.Users
          .Include(u => u.Chats)
          .Where(u => u.Id == user.Id)
          .First()
          .Chats
          .Remove(chat);
      }
    }

    // Add added users
    foreach (Guid userId in updateChat.UserIds)
    {
      AppUser? user = await _context.Users.FindAsync(userId);
      if (!chat.Users.Contains(user))
      {
        chat.Users.Add(user);
        _context.Users
          .Include(u => u.Chats)
          .Where(u => u.Id == user.Id)
          .First()
          .Chats
          .Add(chat);
      }
    }

    chat.Name = updateChat.Name;
    chat.Description = updateChat.Description;
    await _context.SaveChangesAsync();

    return _mapper.Map<Chat_Read>(chat);
  }

  public async Task<bool> DeleteChatAsync(Guid id)
  {
    Chat? deleteChat = _context.Chats.Find(id);

    foreach (AppUser chatUser in deleteChat.Users)
    {
      AppUser? foundUser = await _context.Users.FindAsync(chatUser);
      foundUser?.Chats.Remove(deleteChat);
      try
      {
        _context.Users.Update(foundUser);
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"==EXCEPTION==> {nameof(ChatRepo)} / {nameof(DeleteChatAsync)} : User could not be updated!");
        return false;
      }
    }

    _context.Chats.Remove(deleteChat);
    _context.SaveChanges();

    return true;
  }
}
