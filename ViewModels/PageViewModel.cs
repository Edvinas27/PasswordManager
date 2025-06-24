using CommunityToolkit.Mvvm.ComponentModel;
using PasswordManager.Data;

namespace PasswordManager.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationPageNames _pageName;
}