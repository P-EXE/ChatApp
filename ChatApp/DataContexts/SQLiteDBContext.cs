using ChatApp.Models;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DataContexts;

public class SQLiteDBContext : DbContext
{
  public DbSet<BearerToken> BearerTokens => Set<BearerToken>();
  public DbSet<AppUser> Users => Set<AppUser>();
  public DbSet<AppOwner> Owner => Set<AppOwner>();
  public DbSet<Chat> Chats => Set<Chat>();
  public DbSet<Message> Messages => Set<Message>();

  public SQLiteDBContext(DbContextOptions<SQLiteDBContext> options) : base(options)
  {
    Database.EnsureCreated();
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    builder.Entity<BearerToken>(b =>
    {
      b.HasNoKey();
    });

    builder.Entity<AppUser>(u =>
    {
      u.HasKey(u => u.Id);
      u.HasMany(u => u.Contacts).WithMany();
      u.HasMany(u => u.Chats).WithMany(c => c.Users);
    });

    builder.Entity<Chat>(c =>
    {
      c.HasKey(c => c.Id);
      c.HasMany(c => c.Users)
      .WithMany(c => c.Chats);
    });

    builder.Entity<Message>(m =>
    {
      m.HasKey(m => new { m.ChatId, m.MessageId });
      m.HasOne(m => m.Chat).WithMany(c => c.Messages);
    });
  }
}