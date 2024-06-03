using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class UserProfilePage : ContentPage
{
	private readonly UserProfileVM _vm;
	public UserProfilePage(UserProfileVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}
}