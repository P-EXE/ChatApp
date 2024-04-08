using ChatApp.ViewModels;

namespace ChatApp.Pages;

public partial class SettingsPage : ContentPage
{
	private readonly SettingsVM _vm;
	public SettingsPage(SettingsVM vm)
	{
    _vm = vm;
    BindingContext = _vm;
    InitializeComponent();
	}
}