using System.Windows.Input;
using Betriebsmodi.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Betriebsmodi.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private object? currentView = new Menu();
    
    public ICommand ChangeViewCommand { get; }

    public MainWindowViewModel()
    {
        currentView = new Menu();
        
        ChangeViewCommand = new RelayCommand(() =>
        {
            CurrentView = new GuidedMode();
        });
        
    }
}