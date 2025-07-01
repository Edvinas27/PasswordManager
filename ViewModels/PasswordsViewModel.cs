using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Data;
using PasswordManager.Extensions;
using PasswordManager.Helpers;
using PasswordManager.Models;

namespace PasswordManager.ViewModels;

public partial class PasswordsViewModel : PageViewModel
{
    public ObservableCollection<Password> Passwords { get; }

    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(HasSelectedPassword))]
    private Password? _selectedPassword;
    
    
    
    public PasswordsViewModel()
    {
        PageName = ApplicationPageNames.Passwords;

        var passwords = new List<Password>
        {
            new Password("Email", "strongEmail123!"),
            new Password("Bank", "secureBankPass456$"),
            new Password("Social Media", "socialPass789#"),
            new Password("Work", "workAccess321@"),
            new Password("Gaming", "gameOn567%"),
            new Password("Shopping", "shopSafe999^"),
            new Password("Streaming", "streamflix432&"),
            new Password("Cloud Storage", "cloudSecure888*"),
            new Password("VPN", "vpnAccess555("),
            new Password("IoT Device", "iotDevice123)"),
            new Password("Backup", "backupStrong456_"),
            new Password("Test Account", "testAccount789-"),
            new Password("Legacy System", "legacySystem321+"),
            new Password("Temporary Access", "tempAccess654="),
            new Password("Admin Panel", "adminPanel987!"),
            new Password("API Key", "asdf"),
            new Password("Very strong", "VeryStrongPassword123!@#"),
        };
        Passwords = new ObservableCollection<Password>(passwords);
    }
    
    
    [RelayCommand]
    private void FavouritePassword()
    {
        if (SelectedPassword is not null)
        {
            SelectedPassword.IsFavourite = !SelectedPassword.IsFavourite;
        }
    }
    
    public bool HasSelectedPassword => SelectedPassword is not null;
    public bool SelectedPasswordHasWebsite => SelectedPassword?.Website is not null;
}