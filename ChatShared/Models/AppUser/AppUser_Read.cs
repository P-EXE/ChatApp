using Microsoft.AspNetCore.Identity;

namespace ChatShared.Models;

public class AppUser_Read
{
  public Guid? Id { get; set; }
  public string? DisplayName { get; set; }
  public string? UserName { get; set; }
}
