using Avalonia.Controls;
using Betriebsmodi.UserControls;

namespace Betriebsmodi.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        BlockControl b = new BlockControl('y', 'p');
        BlockContainer.Children.Add(b);
    }
}