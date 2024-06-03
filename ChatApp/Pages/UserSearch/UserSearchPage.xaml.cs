using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class UserSearchPage : ContentPage
{
	private readonly UserSearchVM _vm;
	public UserSearchPage(UserSearchVM vm)
	{
		_vm = vm;
		BindingContext = vm;
		InitializeComponent();
	}
}