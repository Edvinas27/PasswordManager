using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PasswordManager.ViewModels;

public partial class DialogViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isOpen;
    [ObservableProperty] private bool _isConfirmed;

    protected TaskCompletionSource CloseTask = new ();

    public async Task WaitAsync()
    {
        await CloseTask.Task;
    }

    public void Show()
    {
        if(CloseTask.Task.IsCompleted) CloseTask = new TaskCompletionSource();

        
        IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
        
        CloseTask.TrySetResult();
    }
    
    [RelayCommand]
    internal void Add()
    {
        IsConfirmed = true;
        Close();
    }

    [RelayCommand]
    internal void Cancel()
    {
        IsConfirmed = true;
        Close();
    }
}