using Jab;
using Shared.Services;

namespace AvaloniaJabAot.ViewModels;

[ServiceProviderModule]
[Transient<PersonViewModel>(Factory = nameof(Create))]
public partial interface IPersonViewModelFactory
{
    public PersonViewModel Create(string name);
}

public class PersonViewModelFactory : IPersonViewModelFactory
{
    public PersonViewModel Create(string name)
    {
        // Jab doesn't appear to have a way to inject an IServiceProvider here
        // https://github.com/pakrym/jab/issues/139
        var randomService = App.DefaultServiceProvider.GetService<IRandomService>();

        var instance = new PersonViewModel(randomService);
        instance.Name = name;

        return instance;
    }
}