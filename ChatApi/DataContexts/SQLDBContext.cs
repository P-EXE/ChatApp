using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChatShared.Models;

namespace ChatApi.DataContexts;

public class SQLDBContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{

  public DbSet<Chat> Chats => Set<Chat>();
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
