using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class ChatsPage : ContentPage
{
	private readonly ChatsVM _vm;
	public ChatsPage(ChatsVM vm)
	{
    _vm = vm;
		BindingContext = _vm;
    InitializeComponent();
	}
}