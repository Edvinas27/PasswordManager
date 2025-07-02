using PasswordManager.ViewModels;

namespace PasswordManager.Interfaces;

public interface IDialogProvider
{
    DialogViewModel Dialog { get; }
}