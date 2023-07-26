using AvaloniaJabAot.ViewModels;
using AvaloniaJabAot.Views;
using Jab;
using Shared.Services;

namespace AvaloniaJabTest;

[ServiceProvider]
[Singleton<IRandomService, RandomService>]
[Singleton<IPersonViewModelFactory, PersonViewModelFactory>]
[Import<IViewModelRegistrations>]
[Import<IViewRegistrations>]
public partial class AppServiceProvider
{
}

[ServiceProviderModule]
[Singleton<MainWindow>]
[Transient<PersonView>]
[Singleton<LogoView>]
internal interface IViewRegistrations
{
}

[ServiceProviderModule]
[Singleton<LogoViewModel>]
[Singleton<MainWindowViewModel>]
[Transient<PersonViewModel>]
internal interface IViewModelRegistrations
{
}