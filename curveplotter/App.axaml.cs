using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CurvePlotter.ViewModels;
using CurvePlotter.Views;
using System.Linq;

namespace CurvePlotter;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Упрощенная инициализация без Locator
            var vm = new MainWindowViewModel();
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };

            DisableAvaloniaDataAnnotationValidation();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        var pluginsToRemove = BindingPlugins.DataValidators
            .OfType<DataAnnotationsValidationPlugin>()
            .ToArray();

        foreach (var plugin in pluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}