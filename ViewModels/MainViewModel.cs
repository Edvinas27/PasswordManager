using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Data;
using PasswordManager.Factories;
using PasswordManager.Helpers;

namespace PasswordManager.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly PageFactory _pageFactory;
    
    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(MainImage))]
    [NotifyPropertyChangedFor(nameof(MainImageWidth))]
    private bool _sideMenuExpanded = true;

    public bool FavouriteIsActive => CurrentPage.PageName == ApplicationPageNames.Favourites;
    public bool PasswordsIsActive => CurrentPage.PageName == ApplicationPageNames.Passwords;
    public bool PaymentCardsIsActive => CurrentPage.PageName == ApplicationPageNames.PaymentCards;


    public int MainImageWidth => SideMenuExpanded ? 180 : 40;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FavouriteIsActive))]
    [NotifyPropertyChangedFor(nameof(PasswordsIsActive))]
    [NotifyPropertyChangedFor(nameof(PaymentCardsIsActive))]
    private PageViewModel _currentPage;
    
    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        GoToFavouritesPage();
    }
    
    public Bitmap MainImage =>
        ImageHelper.LoadImage(new Uri(
            $"avares://{nameof(PasswordManager)}/Assets/Images/{(SideMenuExpanded ? "MainLogo.png" : "icon.png")}"));


    [RelayCommand]
    private void SideMenuResize() => SideMenuExpanded = !SideMenuExpanded;

    [RelayCommand]
    public void GoToFavouritesPage() => CurrentPage = _pageFactory.Create(ApplicationPageNames.Favourites);
    
    [RelayCommand]
    public void GoToPasswordPage() => CurrentPage = _pageFactory.Create(ApplicationPageNames.Passwords);

    [RelayCommand]
    public void GoToPaymentCardPage() => CurrentPage = _pageFactory.Create(ApplicationPageNames.PaymentCards);
}