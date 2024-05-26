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
    CreateMap<Chat_API, Chat_Read>();
    // MAUI
    CreateMap<Chat_MAUI, Chat_Create>();

    // Transition -> Rest
    // API
    CreateMap<Chat_Create, Chat_API>();
    CreateMap<Chat_Update, Chat_API>();
    // MAUI
    // Fucks up Chat_Read to Chat_MAUI due to Chat_MAUI having AppUsers as an ObservableCollection
    CreateMap<Chat_Read, Chat_MAUI>()
      .ForMember(dest => dest.Users,
        opt => opt.MapFrom(src =>
          src.Users.Cast<ObservableCollection<AppUser>>()
        )
      )
      .ForMember(dest => dest.Messages,
        opt => opt.MapFrom(src =>
          src.Messages.Cast<ObservableCollection<Message_API>>()
        )
      );
  }
}
