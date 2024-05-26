using AutoMapper;
using ChatShared.Models;

namespace ChatShared.Maps;

public class Message_AMProfile : Profile
{
  public Message_AMProfile()
  {
    CreateMap<Message_API, Message_Create>();
    CreateMap<Message_API, Message_Read>();

    CreateMap<Message_Create, Message_API>();
    CreateMap<Message_Read, Message_MAUI>();
  }
}
