using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AvaloniaCommunityToolkitAot.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IPersonViewModelFactory _personFactory;

    public string Greeting => "Welcome to a Community Toolkit-based ViewLocator ready for AOT!";
    public ObservableCollection<PersonViewModel> People { get; }
    [ObservableProperty] private LogoViewModel _logo;

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