using AutoMapper;
using ChatShared.Models;

namespace ChatApi.Models;

public class Chat_AMProfile : Profile
{
  public Chat_AMProfile()
  {
    CreateMap<Chat_DTOCreate, Chat>();
  }
}
