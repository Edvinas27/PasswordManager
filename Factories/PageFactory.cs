using System;
using PasswordManager.Data;
using PasswordManager.ViewModels;

namespace PasswordManager.Factories;

public class PageFactory
{
    private readonly Func<ApplicationPageNames, PageViewModel> _factory;
    
    public PageFactory(Func<ApplicationPageNames, PageViewModel> factory)
    {
        _factory = factory;
    }

    /// <summary>
    /// Creates a new instance of PageViewModel based on the provided ApplicationPageNames via dependency injection.
    /// </summary>
    /// <param name="name">name of the page</param>
    /// <returns>view model of the page</returns>
    public PageViewModel Create(ApplicationPageNames name) => _factory.Invoke(name);
}