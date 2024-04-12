using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class NewChatPage : ContentPage
{
	private readonly NewChatVM _vm;
	public NewChatPage(NewChatVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}
}