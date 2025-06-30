using System;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Data;
using PasswordManager.Factories;
using PasswordManager.Helpers;

namespace PasswordManager.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(MainImage))]
    [NotifyPropertyChangedFor(nameof(MainImageWidth))]
    private bool _sideMenuExpanded = true;

    internal bool FavouriteIsActive => CurrentPage.PageName == ApplicationPageNames.Favourites;
    internal bool PasswordsIsActive => CurrentPage.PageName == ApplicationPageNames.Passwords;
    internal bool PaymentCardsIsActive => CurrentPage.PageName == ApplicationPageNames.PaymentCards;
    internal bool SettingsIsActive => CurrentPage.PageName == ApplicationPageNames.Settings;


    public int MainImageWidth => SideMenuExpanded ? 180 : 40;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FavouriteIsActive))]
    [NotifyPropertyChangedFor(nameof(PasswordsIsActive))]
    [NotifyPropertyChangedFor(nameof(PaymentCardsIsActive))]
    [NotifyPropertyChangedFor(nameof(SettingsIsActive))]
    private PageViewModel _currentPage;
    private readonly PageFactory _pageFactory;


    //This is used for mainview.axaml design datacontext.
    public MainViewModel()
    {
        CurrentPage = new SettingsViewModel();
    }
    
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
    internal void GoToFavouritesPage() => CurrentPage = _pageFactory.Create(ApplicationPageNames.Favourites);
    
    [RelayCommand]
    internal void GoToPasswordPage() => CurrentPage = _pageFactory.Create(ApplicationPageNames.Passwords);

    [RelayCommand]
    internal void GoToPaymentCardPage() => CurrentPage = _pageFactory.Create(ApplicationPageNames.PaymentCards);
    
    [RelayCommand]
    internal void GoToSettingsPage() => CurrentPage = _pageFactory.Create(ApplicationPageNames.Settings);
}