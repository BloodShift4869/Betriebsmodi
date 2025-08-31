using CommunityToolkit.Mvvm.ComponentModel;

namespace Betriebsmodi.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ViewModelBase _CurrentViewModel;

    public MainWindowViewModel()
    {
        _CurrentViewModel = new MenuViewModel(this);
    }
}