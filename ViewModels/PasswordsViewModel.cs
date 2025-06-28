using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PasswordManager.Data;

namespace PasswordManager.ViewModels;

public  class PasswordsViewModel : PageViewModel
{
    public ObservableCollection<Password> Passwords { get; }
    
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
        };
        
        Passwords = new ObservableCollection<Password>(passwords);
    }
}

public record Password(string Name, string Value, bool IsFavourite = false)
{
}