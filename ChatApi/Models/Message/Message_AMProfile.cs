using AutoMapper;
using ChatShared.Models;

namespace ChatApi.Models;

public class Message_AMProfile : Profile
{
  public Message_AMProfile()
  {
    CreateMap<Message, Message_DTOCreate>();
  }
}
