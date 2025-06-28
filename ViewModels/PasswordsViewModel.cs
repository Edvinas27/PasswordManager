using System.Collections.Generic;
using System.Collections.ObjectModel;
using PasswordManager.Data;

namespace PasswordManager.ViewModels;

public class PasswordsViewModel : PageViewModel
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
            new Password("Streaming", "streamflix432&")
        };
        
        Passwords = new ObservableCollection<Password>(passwords);
    }
}

public record Password(string Name, string Value, bool IsFavourite = false)
{
}