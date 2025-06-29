using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PasswordManager.Data;

namespace PasswordManager.ViewModels;

public partial class SettingsViewModel : PageViewModel
{
    [ObservableProperty] 
    private AutoLockTimeOption? _selectedAutoLockTime;

    public SettingsViewModel()
    {
        PageName = ApplicationPageNames.Settings;
        SelectedAutoLockTime = AutoLockTimeOptions[1];
    }

    public ObservableCollection<AutoLockTimeOption> AutoLockTimeOptions { get; } =
    [
        new(1),
        new(5),
        new(10),
        new(15),
        new(30)
    ];
}

public record AutoLockTimeOption(int Minutes)
{
    public string DisplayText => Minutes == 1 ? "1 minute" : $"{Minutes} minutes";
}