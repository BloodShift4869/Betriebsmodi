using Avalonia.Controls;
using Betriebsmodi.ViewModels;

namespace Betriebsmodi.Views;

public partial class CBCView : UserControl
{
    public CBCView(char characterN, char keyN)
    {
        InitializeComponent();
        DataContext = new CBCViewModel(characterN, keyN);
    }
}