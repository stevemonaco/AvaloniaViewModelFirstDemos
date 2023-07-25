using AvaloniaJabAot.ViewModels;
using AvaloniaJabAot.Views;
using Jab;
using Shared.Services;

namespace AvaloniaJabTest;

[ServiceProvider]
[Singleton<IRandomService, RandomService>]
[Singleton<IPersonViewModelFactory, PersonViewModelFactory>]
[Singleton<LogoViewModel>]
[Singleton<MainWindowViewModel>]
[Transient<PersonViewModel>]
[Singleton<MainWindow>]
[Transient<PersonView>]
[Singleton<LogoView>]
public partial class AppServiceProvider
{
}
