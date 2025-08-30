using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Betriebsmodi.Models;

namespace Betriebsmodi.ViewModels;

public partial class ECBViewModel : CipherViewModelBase
{
    public ECBViewModel(char characterN, byte key)
    {
        _model = new BlockModel(characterN, key, false);
        
        CharacterN = characterN;
        CharacterString = ConvertToString(_model.Character, 6);
        KeyString = ConvertToString(_model.Key, 6);
        
        // Setup placeholder
        PlaceholderSetup(6);
        
        // Execute cipher-specific logic
        ExecuteCipher();
        
        _CipherString = ConvertToString(_model.Cipher, 6);
        _OutputString = ConvertToString(_model.Output, 6);
    }

    protected override void PlaceholderSetup(short bitLength)
    {
        for (int i = 0; i < bitLength; i++)
        {
            CipherString.Add("");
            OutputString.Add("");
        }
    }
    
    protected override void ExecuteCipher()
    {
        _model.Cipher = CalculateXOr(_model.Character, _model.Key);
        _model.Output = Permutate(_model.Cipher);
    }
    
    public override async Task StartAnimation(int speed)
    {
        await RevealBits(CipherString, _CipherString, speed);
        await RevealBits(OutputString, _OutputString, speed);
    }
}