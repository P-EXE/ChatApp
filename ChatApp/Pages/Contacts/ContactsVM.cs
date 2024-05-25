using ChatApp.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatApp.ViewModels;

public partial class ContactsVM : ObservableObject
{
  [ObservableProperty]
  private List<Contact> _contacts;
  [ObservableProperty]
  private bool _contactsList_isRefreshing;
  [RelayCommand]
  private async Task RefreshContactsList()
  {
  }
  [RelayCommand]
  private async Task AddContact()
  {
    await Shell.Current.GoToAsync(nameof(UserSearchPage), true, new Dictionary<string, object>
    {
      { "PageMode", UserSearchVM.PageMode.View }
    });
  }
}
