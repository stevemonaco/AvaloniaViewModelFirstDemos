using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaCommunityToolkitAot.ViewModels;
using AvaloniaCommunityToolkitAot.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;

namespace AvaloniaCommunityToolkitAot;
public class ViewLocator : IDataTemplate
{
    private Dictionary<Type, Func<Control?>> _locator = new();

    public ViewLocator()
    {
        RegisterViewFactory<MainWindowViewModel, MainWindow>();
        RegisterViewFactory<PersonViewModel, PersonView>();
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
        return data is ViewModelBase;
    }

    public void RegisterViewFactory<TViewModel>(Func<Control> factory) where TViewModel : class => _locator.Add(typeof(TViewModel), factory);

    public void RegisterViewFactory<TViewModel, TView>()
        where TViewModel : class
        where TView : Control
        => _locator.Add(typeof(TViewModel), Ioc.Default.GetService<TView>);
}