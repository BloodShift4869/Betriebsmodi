using System;
using Betriebsmodi.Models;

namespace Betriebsmodi.ViewModels;

public partial class BlockControlViewModel : ViewModelBase
{
    public char CharacterN { get; }
    public string CharacterString { get; }
    public string KeyString { get; }
    public string CipherString { get; }
    public string OutputString { get; }
    public static string Result { get; set;  }

    private BlockControlModel _model;

    public BlockControlViewModel(char characterN, char keyN)
    {
        _model = new BlockControlModel(characterN, keyN);
        _model.Cipher = CalculateXOr(_model.Character, _model.Key);
        _model.Output = Permutate(_model.Cipher);

        CharacterN = characterN;
        CharacterString = convert(_model.Character, 6);
        KeyString = convert(_model.Key, 6);
        CipherString = convert(_model.Cipher, 6);
        OutputString = convert(_model.Output, 6);
        Result += (char)(_model.Output + 64);
    }

    private byte CalculateXOr(byte c, byte k)
    {
        return (byte)(c ^ k);
    }

    private byte Permutate(byte c)
    {
        int[] pbox = { 3, 0, 1, 5, 2, 4 };
        byte result = 0;
        
        for (int i = 0; i < pbox.Length; i++)
        {
            // Fetch bit at index i
            int bit = (c >> i) & 1;
            
            // Store bit at new position
            result |= (byte)(bit << pbox[i]);
        }
        
        return result;
    }

    private string convert(byte input, short bitLength)
    {
        return Convert.ToString(input, 2).PadLeft(bitLength, '0');
    }
}