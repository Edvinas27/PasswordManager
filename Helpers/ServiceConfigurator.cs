using System;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Data;
using PasswordManager.Factories;
using PasswordManager.ViewModels;

namespace PasswordManager.Helpers;

public static class ServiceConfigurator
{
    /// <summary>
    /// Configures dependency injection services by registering core components
    /// </summary>
    /// <param name="services">The ServiceCollection to configure</param>
    public static void ConfigureServices(IServiceCollection services)
    {
        // ViewModels
        services.AddSingleton<MainViewModel>();
        services.AddTransient<FavouritesViewModel>();
        services.AddTransient<PasswordsViewModel>();
        services.AddTransient<PaymentCardsViewModel>();
        services.AddTransient<SettingsViewModel>();
        
        // Factories
        services.AddSingleton<PageFactory>();
    }
}