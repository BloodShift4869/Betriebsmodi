using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Betriebsmodi.ViewModels;

public class MenuViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;
    
    public MenuViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }
    
    public void OpenGuidedMode()
    {
        _mainViewModel.CurrentViewModel = new GuidedModeViewModel(_mainViewModel);
    }

    public void OpenFreeModeSelection()
    {
        _mainViewModel.CurrentViewModel = new FreeModeSelectionViewModel(_mainViewModel);
    }

    public void ExitApplication()
    {
        Environment.Exit(0);
    }
}