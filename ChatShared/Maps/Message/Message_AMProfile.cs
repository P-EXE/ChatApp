using AutoMapper;
using ChatShared.Models;

namespace ChatShared.Maps;

public class Message_AMProfile : Profile
{
  public Message_AMProfile()
  {
    CreateMap<Message, Message_Create>();
    CreateMap<Message, Message_Read>();

    CreateMap<Message_Create, Message>();
    CreateMap<Message_Read, Message>();
  }
}
