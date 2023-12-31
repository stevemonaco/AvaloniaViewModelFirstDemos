using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Shared.ViewModels;
using AvaloniaJabAot.Views;
using AvaloniaJabTest;
using Avalonia.Controls;

namespace AvaloniaJabAot;
public partial class App : Application
{
    // Factories can't seem to have an IServiceProvider injected into them with Jab yet, so we expose one here
    public static AppServiceProvider DefaultServiceProvider { get; private set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var provider = new AppServiceProvider();
        DefaultServiceProvider = provider;
        var locator = new ViewLocator(provider);
        DataTemplates.Add(locator);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BindingPlugins.DataValidators.RemoveAt(0);

            var vm = provider.GetService<MainWindowViewModel>();
            vm.Greeting = "Welcome to a Jab-based ViewLocator ready for AOT!";

            var view = (Window)locator.Build(vm);
            view.DataContext = vm;

            desktop.MainWindow = view;
        }

        base.OnFrameworkInitializationCompleted();
    }
}