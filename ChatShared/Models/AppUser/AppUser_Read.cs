using Microsoft.AspNetCore.Identity;

namespace ChatShared.Models;

public class AppUser_Read
{
  public string? DisplayName { get; set; }
  public string? UserName { get; set; }
  public Guid? Id { get; set; }
}
