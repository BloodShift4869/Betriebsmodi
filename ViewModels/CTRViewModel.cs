using Betriebsmodi.Models;

namespace Betriebsmodi.ViewModels;

public partial class CTRViewModel : CipherViewModelBase
{
    public string NonceString { get; }
    public string InterimString { get; }

    public CTRViewModel(char characterN, byte key, byte? nonce = null)
    {
        _model = nonce == null ? new BlockModel(characterN, key, true) : new BlockModel(characterN, key, nonce.Value);
        
        CharacterN = characterN;
        CharacterString = ConvertToString(_model.Character, 6);
        KeyString = ConvertToString(_model.Key, 6);
        
        ExecuteCipher();
        
        CipherString = ConvertToString(_model.Cipher, 6);
        OutputString = ConvertToString(_model.Output, 6);
        Result += (char)(_model.Output + 64);
        NonceString = ConvertToString(_model.Nonce, 6);
        InterimString = ConvertToString(_model.InterimResult, 6);
    }

    protected override void ExecuteCipher()
    {
        _model.Cipher = CalculateXOr(_model.Nonce, _model.Key);
        _model.InterimResult = Permutate(_model.Cipher);
        _model.Output = CalculateXOr(_model.InterimResult, _model.Character);
    }
}