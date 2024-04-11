using ChatApp.ViewModels;
using ChatShared.Models;

namespace ChatApp.Views;

public partial class ChatV_List : ContentView
{
  private readonly ChatVM_List _chatVM_List;
  public ChatV_List()
  {
    InitializeComponent();
  }

/*  public ChatV_List(Chat chat)
  {
    _chatVM_List = new ChatVM_List();
    _chatVM_List.Chat = chat;
    BindingContext = _chatVM_List;
    InitializeComponent();
  }*/

/*  public ChatV_List(ChatVM_List chatVM_List, Chat chat)
  {
    _chatVM_List = chatVM_List;
    _chatVM_List.Chat = chat;
    BindingContext = _chatVM_List;
    InitializeComponent();
  }*/
}