using Avalonia.Controls;
using Betriebsmodi.UserControls;

namespace Betriebsmodi.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        BlockContainer.Children.Add(new BlockControl('a', 'X'));
        BlockContainer.Children.Add(new BlockControl('b', 'Y'));
        BlockContainer.Children.Add(new BlockControl('c', 'Z'));
        
    }
}