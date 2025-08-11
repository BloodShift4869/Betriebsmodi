namespace Betriebsmodi.ViewModels;

public partial class GuidedModeViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;
    
    public GuidedModeViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }
}