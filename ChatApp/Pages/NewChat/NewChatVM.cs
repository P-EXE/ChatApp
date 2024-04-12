using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ChatShared.Models;
using ChatApp.Models;

namespace ChatApp.ViewModels;

public partial class NewChatVM : ObservableObject
{
  [ObservableProperty]
  private string _name;
  [ObservableProperty]
  private string _description;
  [ObservableProperty]
  private List<Guid> _members;

  [RelayCommand]
  private async Task CreateChat()
  {
    Chat_DTOCreate chat = new()
    {
      Name = _name,
      Description = _description,
      UserIds = _members
    };
  }
}
