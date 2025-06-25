using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PasswordManager.Data;

namespace PasswordManager.ViewModels;

public partial class SettingsViewModel : PageViewModel
{
    [ObservableProperty] private AutoLockTimeOptions? _selectedAutoLockTime;

    public ObservableCollection<AutoLockTimeOptions> AutoLockTimeOptions { get; } =
    [
        new AutoLockTimeOptions(1),
        new AutoLockTimeOptions(5),
        new AutoLockTimeOptions(10),
        new AutoLockTimeOptions(15),
        new AutoLockTimeOptions(30)
    ];

    public SettingsViewModel()
    {
        PageName = ApplicationPageNames.Settings;
        SelectedAutoLockTime = AutoLockTimeOptions[1];
    }
}

public class AutoLockTimeOptions
{
    public int Minutes { get; }
    public string DisplayText { get; }

    public AutoLockTimeOptions(int minutes)
    {
        Minutes = minutes;
        DisplayText = minutes == 1 ? "1 minutes" : $"{minutes} minutes";
    }
}