using AutoMapper;
using ChatShared.Models;

namespace ChatShared.Maps;

public class AppUser_AMProfile : Profile
{
  public AppUser_AMProfile()
  {
    CreateMap<AppUser, AppUser_Read>();
  }
}
