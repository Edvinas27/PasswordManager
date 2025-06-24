using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Data;
using PasswordManager.Factories;
using PasswordManager.ViewModels;

namespace PasswordManager;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        DataTemplates.Add(new ViewLocator());
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();

        collection.AddSingleton<MainViewModel>();
        collection.AddTransient<FavouritesViewModel>();
        collection.AddTransient<PasswordsViewModel>();
        collection.AddTransient<PaymentCardViewModel>();
        
        collection.AddSingleton<PageFactory>();
        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(x => name => name switch
        {
            ApplicationPageNames.Favourites => x.GetRequiredService<FavouritesViewModel>(),
            ApplicationPageNames.PaymentCards => x.GetRequiredService<PaymentCardViewModel>(),
            ApplicationPageNames.Passwords => x.GetRequiredService<PasswordsViewModel>(),
            _ => throw new InvalidOperationException()
        });
        
        

        var services = collection.BuildServiceProvider();
        
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new Views.MainView
            {
                DataContext = services.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}