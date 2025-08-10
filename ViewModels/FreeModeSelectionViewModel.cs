namespace Betriebsmodi.ViewModels;

public partial class FreeModeSelectionViewModel : ViewModelBase
{
    public enum Mode
    {
        ECB, CBC, CTR
    }
    public string PlainText { get; set; } = "Hello";
    public string Key { get; set; } = "Schluessel";
}