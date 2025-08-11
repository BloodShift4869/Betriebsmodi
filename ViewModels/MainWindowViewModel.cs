using ReactiveUI;

namespace Betriebsmodi.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }
    
    private ViewModelBase _CurrentPage;
    private readonly ViewModelBase[] Pages =
    {
        new MenuViewModel(),
        new GuidedModeViewModel(),
        new FreeModeSelectionViewModel(),
        new FreeModeViewModel(),
    };
    
    public MainWindowViewModel()
    {
        _CurrentPage = Pages[3];
    }
}