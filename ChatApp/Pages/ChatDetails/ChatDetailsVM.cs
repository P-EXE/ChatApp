using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChatApp.ViewModels;

[QueryProperty(nameof(Chat_DTORead2), nameof(Chat))]
public partial class ChatDetailsVM : ObservableObject
{

  public ChatDetailsVM()
  {
  }

  [ObservableProperty]
  private Chat_DTORead2? _chat; 
}
