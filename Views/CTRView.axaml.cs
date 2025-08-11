using Avalonia.Controls;
using Betriebsmodi.ViewModels;

namespace Betriebsmodi.Views;

public partial class CTRView : UserControl
{
    public CTRView(char characterN, char keyN)
    {
        InitializeComponent();
        DataContext = new CTRViewModel(characterN, keyN);
    }
}