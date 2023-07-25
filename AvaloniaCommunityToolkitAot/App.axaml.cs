using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaCommunityToolkitAot.ViewModels;
using AvaloniaCommunityToolkitAot.Views;
using CommunityToolkit.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace AvaloniaCommunityToolkitAot;
public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            var services = new ServiceCollection();
            // You can split registrations across multiple methods, but you need to remember to call them all
            ConfigureServices(services);
            ConfigureViewModels(services);
            ConfigureViews(services);
            var provider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);

            var vm = Ioc.Default.GetService<MainWindowViewModel>();
            var mainWindow = Ioc.Default.GetService<MainWindow>()!;
            mainWindow.DataContext = vm;

            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    [Singleton(typeof(RandomService), typeof(IRandomService))]
    internal static partial void ConfigureServices(IServiceCollection services);

    [Singleton(typeof(MainWindowViewModel))]
    [Transient(typeof(PersonViewModel))]
    [Transient(typeof(PersonViewModelFactory), typeof(IPersonViewModelFactory))]
    internal static partial void ConfigureViewModels(IServiceCollection services);

    [Singleton(typeof(MainWindow))]
    [Transient(typeof(PersonView))]
    internal static partial void ConfigureViews(IServiceCollection services);
}