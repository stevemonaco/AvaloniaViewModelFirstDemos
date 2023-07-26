using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaCommunityToolkitAot.Views;
using CommunityToolkit.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Shared.ViewModels;
using Shared.Services;
using Avalonia.Controls;

namespace AvaloniaCommunityToolkitAot;
public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var locator = new ViewLocator();
        DataTemplates.Add(locator);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BindingPlugins.DataValidators.RemoveAt(0);

            var services = new ServiceCollection();
            // You can split registrations across multiple methods or classes, but you need to remember to call them all
            ConfigureServices(services);
            ConfigureViewModels(services);
            ConfigureViews(services);
            var provider = services.BuildServiceProvider(); // Warning in MEDI 7.0, fixed in 8.0

            Ioc.Default.ConfigureServices(provider);

            var vm = Ioc.Default.GetService<MainWindowViewModel>();
            vm!.Greeting = "Welcome to a Community Toolkit-based ViewLocator ready for AOT!";
            var view = (Window)locator.Build(vm);
            view.DataContext = vm;

            desktop.MainWindow = view;
        }

        base.OnFrameworkInitializationCompleted();
    }

    [Singleton(typeof(RandomService), typeof(IRandomService))]
    internal static partial void ConfigureServices(IServiceCollection services);

    [Singleton(typeof(MainWindowViewModel))]
    [Singleton(typeof(LogoViewModel))]
    [Transient(typeof(PersonViewModel))]
    [Singleton(typeof(PersonViewModelFactory), typeof(IPersonViewModelFactory))]
    internal static partial void ConfigureViewModels(IServiceCollection services);

    [Singleton(typeof(MainWindow))]
    [Singleton(typeof(LogoView))]
    [Transient(typeof(PersonView))]
    internal static partial void ConfigureViews(IServiceCollection services);
}