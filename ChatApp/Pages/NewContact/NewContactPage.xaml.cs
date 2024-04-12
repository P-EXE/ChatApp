using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class NewContactPage : ContentPage
{
	private readonly NewContactVM _vm;
	public NewContactPage(NewContactVM vm)
	{
		_vm = vm;
		BindingContext = vm;
		InitializeComponent();
	}
}