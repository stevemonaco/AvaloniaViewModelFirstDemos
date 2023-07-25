using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaJabAot.ViewModels;
public partial class LogoViewModel : ObservableObject
{
    [ObservableProperty] private string _description = "This is the LogoViewModel";
}
