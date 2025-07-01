using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Models;

namespace PasswordManager.ViewModels;

public partial class AddDataViewModel : DialogViewModel
{
    public required PasswordDto Password { get; set; }
    
    [ObservableProperty]
    private bool _isConfirmed;
    
    [RelayCommand]
    public void Add()
    {
        IsConfirmed = true;
        Close();
    }

    [RelayCommand]
    public void Cancel()
    {
        IsConfirmed = true;
        Close();
    }
}