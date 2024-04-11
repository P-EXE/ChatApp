using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class ContactsPage : ContentPage
{
	private readonly ContactsVM _vm;
	public ContactsPage(ContactsVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
    InitializeComponent();
	}
}