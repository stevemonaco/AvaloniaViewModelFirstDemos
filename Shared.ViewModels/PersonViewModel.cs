using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Services;

namespace Shared.ViewModels;
public partial class PersonViewModel : ObservableObject
{
    [ObservableProperty] private string? _name;
    [ObservableProperty] private int _randomValue;

    private readonly IRandomService _randomService;

    public PersonViewModel(IRandomService randomService)
    {
        _randomService = randomService;
        NewRandom();
    }

    [RelayCommand]
    public void NewRandom()
    {
        RandomValue = _randomService.GetNext(1, 100);
    }
}
