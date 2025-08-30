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
        
        ExecuteCipher();
        
        CipherString = ConvertToString(_model.Cipher, 6);
        OutputString = ConvertToString(_model.Output, 6);
    }

    protected override void ExecuteCipher()
    {
        _model.Cipher = CalculateXOr(_model.Character, _model.Key);
        _model.Output = Permutate(_model.Cipher);
    }
}