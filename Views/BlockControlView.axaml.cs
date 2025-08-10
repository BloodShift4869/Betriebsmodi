using Avalonia.Controls;
using Betriebsmodi.ViewModels;

namespace Betriebsmodi.Views;

public partial class BlockControlView : UserControl
{
    public BlockControlView(char characterN, char keyN)
    {
        InitializeComponent();
        DataContext = new BlockControlViewModel(characterN, keyN);
    }
}