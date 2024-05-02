using AutoMapper;
using ChatShared.Models;

namespace ChatShared.Maps;

public class Message_AMProfile : Profile
{
  public Message_AMProfile()
  {
    CreateMap<Message, Message_DTOCreate>();
    CreateMap<Message, Message_DTORead1>();
  }
}
