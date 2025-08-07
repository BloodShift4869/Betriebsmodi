using Avalonia.Controls;
using Betriebsmodi.ViewModels;

namespace Betriebsmodi.UserControls;

public partial class BlockControl : UserControl
{
    public BlockControl(char characterN, char keyN)
    {
        InitializeComponent();

        DataContext = new BlockControlViewModel(characterN, keyN);
    }
}