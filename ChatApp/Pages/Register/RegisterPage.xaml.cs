using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class RegisterPage : ContentPage
{
  private readonly RegisterVM _vm;
	public RegisterPage(RegisterVM vm)
	{
    _vm = vm;
    BindingContext = _vm;
    InitializeComponent();
	}
}