using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Betriebsmodi.ViewModels;

public partial class FreeModeViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;
    
    public FreeModeSelectionViewModel.Mode Mode { get; }
    public string PlainText { get; }
    public byte Key { get; }
    public string Cores { get; } = "1";
    public string MsWhole { get; } = "2";
    public string MsDecimal { get; } = "41";
    
    public ObservableCollection<CipherViewModelBase> ModeViewModel { get; } = new();
    
    public bool IsECB => Mode == FreeModeSelectionViewModel.Mode.ECB;
    public bool IsCBC => Mode == FreeModeSelectionViewModel.Mode.CBC;
    public bool IsCTR => Mode == FreeModeSelectionViewModel.Mode.CTR;

    public FreeModeViewModel(MainWindowViewModel mainViewModel, FreeModeSelectionViewModel.Mode mode, string plainText, string key)
    {
        _mainViewModel = mainViewModel;
        Mode = mode;
        PlainText = plainText;
        Key = Convert.ToByte(key, 2);
        
        BuildModeViewModel();
        _ = StartAnimation(300);
    }
    
    private void BuildModeViewModel()
    {
        if (string.IsNullOrEmpty(PlainText))
            return;
        
        byte nonce = 0;
        
        for (int i = 0; i < PlainText.Length; i++)
        {
            switch (Mode)
            {
                case FreeModeSelectionViewModel.Mode.ECB:
                    ModeViewModel.Add(new ECBViewModel(PlainText[i], Key));
                    break;
                case FreeModeSelectionViewModel.Mode.CBC:
                    if (i > 0)
                    {
                        CBCViewModel cbc = new CBCViewModel(PlainText[i], Key, nonce);
                        nonce = Convert.ToByte(cbc._OutputString, 2);
                        ModeViewModel.Add(cbc);
                    }
                    else
                    {
                        CBCViewModel cbc = new CBCViewModel(PlainText[i], Key);
                        nonce = Convert.ToByte(cbc._OutputString, 2);
                        ModeViewModel.Add(cbc);
                    }
                    break;
                case FreeModeSelectionViewModel.Mode.CTR:
                    CTRViewModel ctr;
                    if (i > 0)
                    {
                        ctr = new CTRViewModel(PlainText[i], Key, nonce);
                    }
                    else
                    {
                        ctr = new CTRViewModel(PlainText[i], Key);
                    }
                    ModeViewModel.Add(ctr);
                    nonce = Convert.ToByte(ctr._NonceString, 2);
                    nonce++;
                    break;
            }
        }
    }

    private async Task StartAnimation(int speed)
    {
        foreach (var vm in ModeViewModel) await vm.StartAnimation(speed);
    }
}