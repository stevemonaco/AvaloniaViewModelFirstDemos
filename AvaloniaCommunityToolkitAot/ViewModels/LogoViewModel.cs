using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaCommunityToolkitAot.ViewModels;
public partial class LogoViewModel : ObservableObject
{
    [ObservableProperty] private string _description = "This is the LogoViewModel";
}
