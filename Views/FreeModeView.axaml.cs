using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Betriebsmodi.Views;

public partial class FreeModeView : UserControl
{
    public FreeModeView()
    {
        InitializeComponent();
        BlockContainer.Children.Add(new BlockControlView('a', 'X'));
    }
}