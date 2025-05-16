using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.IOEDemo.ViewModels;
using Avalonia.IOEDemo.Views;
using Avalonia.Markup.Xaml;

namespace Avalonia.IOEDemo;

public partial class App : Application
{
    public MainViewModel MainViewModel { get; } = new();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = MainViewModel
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = MainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
