using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class ChatDetailsPage : ContentPage
{
	private readonly ChatDetailsVM _vm;
	public ChatDetailsPage(ChatDetailsVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}
}