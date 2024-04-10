using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class LoginPage : ContentPage
{
	private readonly LoginVM _vm;
	public LoginPage(LoginVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}
}