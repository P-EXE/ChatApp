using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class ChatPage : ContentPage
{
	private readonly ChatVM _vm;
	public ChatPage(ChatVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}
}