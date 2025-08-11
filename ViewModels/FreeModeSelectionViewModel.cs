using System;
using System.Collections.Generic;

namespace Betriebsmodi.ViewModels;

public partial class FreeModeSelectionViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;
    
    public enum Mode
    {
        ECB, CBC, CTR
    }
    
    public IEnumerable<Mode> AvailableModes { get; } = Enum.GetValues<Mode>();

    public Mode SelectedMode { get; set; } = Mode.ECB;
    public string PlainText { get; set; } = "Hello";
    public string Key { get; set; } = "Schluessel";

    public FreeModeSelectionViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    public void OpenFreeMode()
    {
        _mainViewModel.NavigateTo(new FreeModeViewModel(_mainViewModel, SelectedMode, PlainText, Key));
    }
}