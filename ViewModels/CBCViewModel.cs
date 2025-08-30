using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Betriebsmodi.Models;

namespace Betriebsmodi.ViewModels;

public partial class CBCViewModel : CipherViewModelBase
{
    public ObservableCollection<string> NonceString { get; } = new();
    public ObservableCollection<string> InterimString { get; } = new();
    private string _NonceString { get; }
    private string _InterimString { get; }
    
    public CBCViewModel(char characterN, byte key, byte? nonce = null)
    {
        _model = nonce == null ? new BlockModel(characterN, key, true) : new BlockModel(characterN, key, nonce.Value);
        
        CharacterN = characterN;
        CharacterString = ConvertToString(_model.Character, 6);
        KeyString = ConvertToString(_model.Key, 6);
        
        // Setup placeholder
        PlaceholderSetup(6);
        
        // Execute cipher-specific logic
        ExecuteCipher();
        
        _CipherString = ConvertToString(_model.Cipher, 6);
        _OutputString = ConvertToString(_model.Output, 6);
        Result += (char)(_model.Output + 64);
        _NonceString = ConvertToString(_model.Nonce, 6);
        _InterimString = ConvertToString(_model.InterimResult, 6);
    }

    protected override void PlaceholderSetup(short bitLength)
    {
        for (int i = 0; i < bitLength; i++)
        {
            CipherString.Add("");
            OutputString.Add("");
            NonceString.Add("");
            InterimString.Add("");
        }
    }

    protected override void ExecuteCipher()
    {
        _model.InterimResult = CalculateXOr(_model.Character, _model.Nonce);
        _model.Cipher = CalculateXOr(_model.InterimResult, _model.Key);
        _model.Output = Permutate(_model.Cipher);
    }


    public override async Task StartAnimation(int speed)
    {
        await RevealBits(NonceString, _NonceString, speed);
        await RevealBits(InterimString, _InterimString, speed);
        await RevealBits(CipherString, _CipherString, speed);
        await RevealBits(OutputString, _OutputString, speed);
    }
}