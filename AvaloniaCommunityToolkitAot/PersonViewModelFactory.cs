using AvaloniaCommunityToolkitAot.ViewModels;
using Shared.Services;

namespace AvaloniaCommunityToolkitAot;

public partial interface IPersonViewModelFactory
{
    public PersonViewModel Create(string name);
}

public class PersonViewModelFactory : IPersonViewModelFactory
{
    private readonly IRandomService _randomService;

    public PersonViewModelFactory(IRandomService randomService)
    {
        _randomService = randomService;
    }

    public PersonViewModel Create(string name)
    {
        var instance = new PersonViewModel(_randomService);
        instance.Name = name;

        return instance;
    }
}