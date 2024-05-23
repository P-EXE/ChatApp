using AutoMapper;
using ChatShared.Models;

namespace ChatShared.Maps;

public class Chat_AMProfile : Profile
{
  public Chat_AMProfile()
  {
    CreateMap<Chat_Create, Chat>();
    CreateMap<Chat_Update, Chat>();
    CreateMap<Chat, Chat_Read>();
  }
}
