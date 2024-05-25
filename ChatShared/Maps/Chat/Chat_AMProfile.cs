using AutoMapper;
using ChatShared.Models;

namespace ChatShared.Maps;

public class Chat_AMProfile : Profile
{
  public Chat_AMProfile()
  {
    CreateMap<Chat_Create, Chat_API>();
    CreateMap<Chat_Update, Chat_API>();
    CreateMap<Chat_API, Chat_Read>();
  }
}
