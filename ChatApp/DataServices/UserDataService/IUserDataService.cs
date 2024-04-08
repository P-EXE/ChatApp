using ChatShared.Models;

namespace ChatApp.DataServices;

public interface IUserDataService
{
  Task<AppUser?> CreateUserAsync(AppUser_DTOCreate user);
  Task<BearerToken?> ValidateUserAsync(AppUser_DTOCreate createUser);
  Task<BearerToken?> RenewBearerTokenAsync(BearerToken bearerToken);
  Task<AppUser?> GetUserByIdAsync(Guid usderId);
}
