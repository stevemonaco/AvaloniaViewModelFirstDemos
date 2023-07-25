using AvaloniaCommunityToolkitAot.ViewModels;
using Shared.Services;
using System;

namespace AvaloniaCommunityToolkitAot;

public partial interface IPersonViewModelFactory
{
    public PersonViewModel Create(string name);
}

public class PersonViewModelFactory : IPersonViewModelFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PersonViewModelFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public PersonViewModel Create(string name)
    {
        var randomService = (IRandomService)_serviceProvider.GetService(typeof(IRandomService))!;

        var instance = new PersonViewModel(randomService);
        instance.Name = name;

        return instance;
    }
}