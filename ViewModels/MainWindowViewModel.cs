namespace Betriebsmodi.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Mode { get; } = "ECB";
    public string Cores { get; } = "1";
    public string MsWhole { get; } = "2";
    public string MsDecimal { get; } = "41";
}