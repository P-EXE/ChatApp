using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChatShared.Models;

namespace ChatApi.DataContexts
{
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
        m.HasKey(m => new {m.ChatId, m.MessageId});
        m.HasOne(m => m.Chat).WithMany(c => c.Messages);
      });
    }
  }
}
