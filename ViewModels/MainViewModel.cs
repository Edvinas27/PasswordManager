using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
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

    public bool FavouriteIsActive => CurrentPage == _favourites;
    public bool PasswordsIsActive => CurrentPage == _passwords;
    public bool PaymentCardsIsActive => CurrentPage == _paymentCard;


    public int MainImageWidth => SideMenuExpanded ? 180 : 40;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FavouriteIsActive))]
    [NotifyPropertyChangedFor(nameof(PasswordsIsActive))]
    [NotifyPropertyChangedFor(nameof(PaymentCardsIsActive))]
    private ViewModelBase _currentPage;

    private readonly FavouritesViewModel _favourites = new();
    private readonly PasswordsViewModel _passwords = new();
    private readonly PaymentCardViewModel _paymentCard = new();
    
    public MainViewModel()
    {
        CurrentPage = _favourites;
    }
    
    public Bitmap MainImage =>
        ImageHelper.LoadImage(new Uri(
            $"avares://{nameof(PasswordManager)}/Assets/Images/{(SideMenuExpanded ? "MainLogo.png" : "icon.png")}"));


    [RelayCommand]
    private void SideMenuResize() => SideMenuExpanded = !SideMenuExpanded;

    [RelayCommand]
    public void GoToFavouritesPage() => CurrentPage = _favourites;
    
    [RelayCommand]
    public void GoToPasswordPage() => CurrentPage = _passwords;
    
    [RelayCommand]
    public void GoToPaymentCardPage() => CurrentPage = _paymentCard;
}