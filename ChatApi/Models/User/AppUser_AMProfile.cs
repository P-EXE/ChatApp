using AutoMapper;
using ChatShared.Models;

namespace ChatApi.Models;

public class AppUser_AMProfile : Profile
{
  public AppUser_AMProfile()
  {
    CreateMap<AppUser, AppUser_DTORead1>();
  }
}
