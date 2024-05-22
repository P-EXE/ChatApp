using ChatApp.Pages;
using ChatApp.Services;
using ChatShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ChatApp.ViewModels;

[QueryProperty("Chat", nameof(Chat))]
public partial class ChatVM : ObservableObject
{
  private readonly IMessageService _messageService;
  public ChatVM(IMessageService messageService)
  {
    _messageService = messageService;
  }

  [ObservableProperty]
  private Chat_DTORead _chat;
  [ObservableProperty]
  private ObservableCollection<Message> _messages = new();
  [ObservableProperty]
  private Message_DTOCreate _message = new();

  [ObservableProperty]
  private int _position = 0;

  [RelayCommand]
  private async Task GetMessages()
  {
    List<Message>? messagesOld = Messages.ToList();

    IEnumerable<Message>? messagesNew;
    messagesNew = await _messageService.GetMessagesOfChatAsync(Chat.Id.ToString(), Position);

    messagesOld.AddRange(messagesNew);

    Messages = new(messagesOld);
  }

  [RelayCommand]
  private async Task SendMessage()
  {
    Message_DTOCreate createMessage = new()
    {
      Text = Message.Text
    };
    await _messageService.SendMessageToChatAsync(Chat.Id.ToString(), createMessage);
  }

  [RelayCommand]
  private async Task NavToChatDetails()
  {
    await Shell.Current.GoToAsync(nameof(ChatDetailsPage), true, new Dictionary<string, object>
    {
      { "Chat", Chat },
      { "PageMode", ChatDetailsVM.PageMode.View }
    });
  }
}
