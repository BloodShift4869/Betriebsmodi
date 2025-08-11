using System;

namespace Betriebsmodi.ViewModels;

public partial class FreeModeViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;
    
    public FreeModeSelectionViewModel.Mode Mode { get; }
    public string Cores { get; } = "1";
    public string MsWhole { get; } = "2";
    public string MsDecimal { get; } = "41";

    public FreeModeViewModel(MainWindowViewModel mainViewModel, FreeModeSelectionViewModel.Mode mode, string plainText, string key)
    {
        _mainViewModel = mainViewModel;
        Mode = mode;
        
        
    }
}