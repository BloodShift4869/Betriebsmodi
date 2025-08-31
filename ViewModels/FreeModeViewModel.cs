using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Betriebsmodi.ViewModels;

public partial class FreeModeViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;

    private int[] speedSelection = new[] { 300, 150 };
    
    public FreeModeSelectionViewModel.Mode Mode { get; }
    public string PlainText { get; }
    public byte Key { get; }
    public string Cores { get; } = "1";

    [ObservableProperty]
    private int _MsWhole = 0;
    
    [ObservableProperty]
    private int _MsDecimal = 0;
    
    [ObservableProperty]
    private int _Speed = 300;

    public ObservableCollection<CipherViewModelBase> ModeViewModel { get; } = new();

    public bool IsECB => Mode == FreeModeSelectionViewModel.Mode.ECB;
    public bool IsCBC => Mode == FreeModeSelectionViewModel.Mode.CBC;
    public bool IsCTR => Mode == FreeModeSelectionViewModel.Mode.CTR;

    private bool isRunning = true;

    public FreeModeViewModel(MainWindowViewModel mainViewModel, FreeModeSelectionViewModel.Mode mode, string plainText,
        string key)
    {
        _mainViewModel = mainViewModel;
        Mode = mode;
        PlainText = plainText;
        Key = Convert.ToByte(key, 2);
        Speed = speedSelection[0];

        BuildModeViewModel();
        _ = StartAnimation(1000);
        _ = Timer();
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

    public void ChangeSpeed(int selection)
    {
        Speed = speedSelection[selection];
        
        foreach (var vm in ModeViewModel) vm.AnimationSpeed = Speed;
    }

    private async Task StartAnimation(int delay)
    {
        await Task.Delay(delay);
        foreach (var vm in ModeViewModel) await vm.StartAnimation(Speed);
        isRunning = false;
    }

    private async Task Timer()
    {
        while (isRunning)
        {
            MsDecimal++;
            
            if (MsDecimal > 59)
            {
                MsDecimal = 0;
                MsWhole++;
            }

            await Task.Delay(Speed/2);
        }
    }
}