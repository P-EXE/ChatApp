using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ChatShared.Models;
using ChatApp.Models;
using ChatApp.Services;

namespace ChatApp.ViewModels;

public partial class NewChatVM : ObservableObject
{
  private readonly IChatService _chatService;
  public NewChatVM(IChatService chatService)
  {
    _chatService = chatService;
  }

  [ObservableProperty]
  private bool _available = true;

  [ObservableProperty]
  private string _name;
  [ObservableProperty]
  private string _description;
  [ObservableProperty]
  private List<Guid> _members;

  [RelayCommand]
  private async Task CreateChat()
  {
    Available = false;
    Chat_DTOCreate createChat = new()
    {
      Name = _name,
      Description = _description,
      UserIds = _members
    };
    Guid? chatId = await _chatService.CreateChatAsync(createChat);
    if (chatId == null) return;
    await NavToChat(chatId);
    Available = true;
  }

  private async Task NavToChat(Guid? chatId)
  {
    throw new NotImplementedException();
  }
}
