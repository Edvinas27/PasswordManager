using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PasswordManager.ViewModels;

public partial class DialogViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isOpen;

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
}