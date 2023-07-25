using AvaloniaJabAot.ViewModels;
using AvaloniaJabAot.Views;
using Jab;
using Shared.Services;

namespace AvaloniaJabTest;

[ServiceProvider]
[Singleton<IRandomService, RandomService>]
[Singleton<IPersonViewModelFactory, PersonViewModelFactory>]
[Singleton<MainWindowViewModel>]
[Singleton<MainWindow>]
[Transient<PersonViewModel>]
[Transient<PersonView>]
public partial class AppServiceProvider
{
}
