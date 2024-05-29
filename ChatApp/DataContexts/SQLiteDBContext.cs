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
  public DbSet<Chat> Chats => Set<Chat>();
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
                    .HasOne<Chat>()
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
      m.HasOne(m => m.User)
      .WithMany(u => u.Messages)
      .OnDelete(DeleteBehavior.Cascade);

      m.HasOne(m => m.Chat)
      .WithMany(c => c.Messages)
      .OnDelete(DeleteBehavior.Cascade);
    });
  }
}