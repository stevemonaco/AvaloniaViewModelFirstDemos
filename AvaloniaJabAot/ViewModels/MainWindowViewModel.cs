using System.Collections.ObjectModel;

namespace AvaloniaJabAot.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IPersonViewModelFactory _personFactory;

    public string Greeting => "Welcome to a Jab-based ViewLocator ready for AOT!";
    public ObservableCollection<PersonViewModel> People { get; }

    public MainWindowViewModel(IPersonViewModelFactory personFactory)
    {
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
