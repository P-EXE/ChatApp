using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChatShared.Models;

namespace ChatApi.DataContexts;

public class SQLDBContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{

  public DbSet<Chat_API> Chats => Set<Chat_API>();
  public DbSet<Message> Messages => Set<Message>();

  public SQLDBContext(DbContextOptions<SQLDBContext> options) : base(options)
  {
    Database.EnsureCreated();
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

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
