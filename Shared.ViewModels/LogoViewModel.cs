using CommunityToolkit.Mvvm.ComponentModel;

namespace Shared.ViewModels;
public partial class LogoViewModel : ObservableObject
{
    [ObservableProperty] private string _description = "This is the LogoViewModel";
}
