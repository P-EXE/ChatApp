using ChatApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.DataContexts
{
  public class SQLDBContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
  {
    public SQLDBContext(DbContextOptions<SQLDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<User>();
    }
  }
}
