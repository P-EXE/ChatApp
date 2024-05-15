using ChatApp.Messaging;
using ChatApp.Pages;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ChatApp.ViewModels;

[QueryProperty(nameof(Chat), nameof(Chat))]
public partial class ChatDetailsVM : ObservableObject
{

  public ChatDetailsVM()
  {
    WeakReferenceMessenger.Default.Register<PageReturnObjectMessage<AppUser>>(this, (r, m) =>
    {
      AddMember(m.Value);
    });

    if(Chat == null)
    {
      Chat = new() { Users = new List<AppUser>() };
    }
  }

  [ObservableProperty]
  private Chat_DTORead _chat;

  private async Task AddMember(AppUser member)
  {
    Chat.Users = Chat.Users.Append(member).ToList();
  }
  [RelayCommand]
  private async Task NavToUserSearchPage()
  {
    await Shell.Current.GoToAsync(nameof(UserSearchPage), true, new Dictionary<string, object>
    {
      { "PageMode", UserSearchVM.PageMode.Return }
    });
  }
}
