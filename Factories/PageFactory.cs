using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Data;
using PasswordManager.ViewModels;

namespace PasswordManager.Factories;

public class PageFactory(IServiceProvider provider)
{
    private readonly Dictionary<ApplicationPageNames, Type> _pages = InitializePages();

    /// <summary>
    /// Creates a new instance of a PageViewModel based on the provided ApplicationPageNames via dependency injection.
    /// </summary>
    /// <param name="name">Enum value identifying ViewModel</param>
    /// <returns>An instance of the requested PageViewModel</returns>
    /// <exception cref="ArgumentException">Thrown when page type is not registered</exception>
    public PageViewModel Create(ApplicationPageNames name)
    {
        if (!_pages.TryGetValue(name, out var viewModelType))
        {
            throw new ArgumentException($"Unknown page type: {name}", nameof(name));
        }
        
        return (PageViewModel)provider.GetRequiredService(viewModelType);
    }
    
    /// <summary>
    /// Initializes the dictionary mapping ApplicationPageNames to their corresponding ViewModel types using refleciton.
    /// </summary>
    /// <returns>Dictionary mapping page names to their ViewModel types</returns>
    /// <exception cref="InvalidOperationException">Thrown when a ViewModel class matching the naming convention is not  found for a page name</exception>

    private static Dictionary<ApplicationPageNames, Type> InitializePages()
    {
        var viewModelTypes = typeof(PageViewModel)
            .Assembly
            .GetTypes()
            .Where(t => !t.IsAbstract && typeof(PageViewModel).IsAssignableFrom(t));

        return Enum.GetValues<ApplicationPageNames>()
            .ToDictionary(key => key,
                value => viewModelTypes.FirstOrDefault(t => t.Name == $"{value}ViewModel") ?? throw new InvalidOperationException($"No view model found for {value}.")
            );
    }
}