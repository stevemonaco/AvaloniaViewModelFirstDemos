# AvaloniaViewModelFirstDemos

Various demos that use ViewModel-First MVVM in Avalonia. This means that the ViewModel is always created first and the View is resolved/created based on the ViewModel's type or shape. Approaches typically include some combination of a ViewLocator, `ContentControl`s, and `DataTemplate`s.

## AOT-friendly ViewLocators

Currently, these demos have equal functionality, but have different technical implementations. Service registration for dependency injection has traditionally been reflection-heavy, and these demos show newer source generator approaches to eliminate that problem. This opens up trimming and Ahead-Of-Time compilation support while keeping ViewModel-First support with ViewLocator. The ViewLocator could be enhanced for broader view-caching or alternatively skipped altogether to instead define every ViewModel -> View mapping as a `DataTemplate` in XAML.

### AvaloniaCommunityToolkitAot

Demonstrates how to use the lab preview of [CommunityToolkit.Extensions.DependencyInjection](https://github.com/CommunityToolkit/Labs-Windows/discussions/463) with `Microsoft.Extensions.DependencyInjection` to create an AOT-friendly ViewLocator.

### AvaloniaJabAot

Demonstrates how to use [Jab](https://github.com/pakrym/jab) to create an AOT-friendly ViewLocator.
