using ChatApp.Models;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DataContexts;

public class SQLiteDBContext : DbContext
{
  // Client only
  public DbSet<BearerToken> BearerTokens => Set<BearerToken>();
  // Client only
  public DbSet<AppUser> Users => Set<AppUser>();
  public DbSet<AppOwner> Owner => Set<AppOwner>();
  // Shared with API
  public DbSet<Chat_API> Chats => Set<Chat_API>();
  public DbSet<Message> Messages => Set<Message>();

  public SQLiteDBContext(DbContextOptions<SQLiteDBContext> options) : base(options)
  {
    Database.EnsureCreated();
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    // Client only
    builder.Entity<BearerToken>(b =>
    {
      b.HasNoKey();
    });

    // Shared with API
    builder.Entity<AppUser>(u =>
    {
      u.HasKey(u => u.Id);

      u.HasMany(u => u.Chats)
      .WithMany(c => c.Users)
      .UsingEntity<Dictionary<Guid, object>>(
                "UserChat",
                j => j
                    .HasOne<Chat_API>()
                    .WithMany()
                    .HasForeignKey("ChatId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<AppUser>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade));
    });

    // Shared with API
    builder.Entity<Message>(m =>
    {
      m.HasKey(m => new { m.UserId, m.ChatId, m.MessageId });

      m.HasOne(m => m.User)
      .WithMany(u => u.Messages)
      .HasForeignKey(m => m.UserId)
      .OnDelete(DeleteBehavior.Cascade);

      m.HasOne(m => m.Chat)
      .WithMany(c => c.Messages)
      .HasForeignKey(m => m.ChatId)
      .OnDelete(DeleteBehavior.Cascade);
    });
  }
}