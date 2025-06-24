using System;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Helpers;

namespace PasswordManager.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(MainImage))]
    [NotifyPropertyChangedFor(nameof(MainImageWidth))]
    private bool _sideMenuExpanded = true;


    public int MainImageWidth => SideMenuExpanded ? 180 : 40;
    public Bitmap MainImage =>
        ImageHelper.LoadImage(new Uri(
            $"avares://{nameof(PasswordManager)}/Assets/Images/{(SideMenuExpanded ? "MainLogo.png" : "icon.png")}"));

    [RelayCommand]
    private void SideMenuResize()
    {
        SideMenuExpanded = !SideMenuExpanded;
        
    }
}