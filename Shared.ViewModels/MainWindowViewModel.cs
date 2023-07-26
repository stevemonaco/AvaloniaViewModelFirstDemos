using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Shared.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IPersonViewModelFactory _personFactory;

    public ObservableCollection<PersonViewModel> People { get; }
    [ObservableProperty] private LogoViewModel _logo;
    [ObservableProperty] private string? _greeting;

    public MainWindowViewModel(LogoViewModel logo, IPersonViewModelFactory personFactory)
    {
        Logo = logo;
        _personFactory = personFactory;

        People = new()
        {
            personFactory.Create("John"),
            personFactory.Create("Rick"),
            personFactory.Create("Anna"),
            personFactory.Create("Troy"),
        };
    }
}