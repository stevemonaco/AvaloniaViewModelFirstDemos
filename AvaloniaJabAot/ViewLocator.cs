using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaJabAot.Views;
using AvaloniaJabAot.ViewModels;
using AvaloniaJabTest;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaJabAot;
public class ViewLocator : IDataTemplate
{
    private AppServiceProvider _appServiceProvider;
    private Dictionary<Type, Func<Control>> _locator = new();

    public ViewLocator(AppServiceProvider appServiceProvider)
    {
        _appServiceProvider = appServiceProvider;
        RegisterViewFactory<MainWindowViewModel, MainWindow>();
        RegisterViewFactory<PersonViewModel, PersonView>();
        RegisterViewFactory<LogoViewModel, LogoView>();
    }

    public Control Build(object? data)
    {
        if (data is null)
            return new TextBlock { Text = $"No VM provided" };

        _locator.TryGetValue(data.GetType(), out var factory);

        return factory?.Invoke() ?? new TextBlock { Text = $"VM Not Registered: {data.GetType()}" };
    }

    public bool Match(object? data)
    {
        return data is ObservableObject;
    }

    public void RegisterViewFactory<TViewModel>(Func<Control> factory) where TViewModel : class => _locator.Add(typeof(TViewModel), factory);

    public void RegisterViewFactory<TViewModel, TView>() 
        where TViewModel : class
        where TView : Control
        => _locator.Add(typeof(TViewModel), _appServiceProvider.GetService<TView>);
}