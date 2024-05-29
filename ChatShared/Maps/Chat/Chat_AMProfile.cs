using AutoMapper;
using ChatShared.Models;
using System.Collections.ObjectModel;

namespace ChatShared.Maps;

public class Chat_AMProfile : Profile
{
  public Chat_AMProfile()
  {
    // Rest -> Transition
    // API
    CreateMap<Chat, Chat_Read>();
    // MAUI
    CreateMap<Chat, Chat_Create>();

    // Transition -> Rest
    // API
    CreateMap<Chat_Create, Chat>();
    CreateMap<Chat_Update, Chat>();
    // MAUI
    CreateMap<Chat_Read, Chat>();
  }
}
