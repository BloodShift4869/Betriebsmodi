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
    }

    private byte CalculateXOr(byte c, byte k)
    {
        return (byte)(c ^ k);
    }

    private byte Permutate(byte c)
    {
        // TODO Resolve Array out of bounds error
        int[] pbox = { 1, 0, 3, 2, 4, 5 };
        /*char[] output = new char[8];
        string cipher = convert(c, 6);

        for (int i = 0; i < pbox.Length; i++)
        {
            output[pbox[i]] = cipher[i];
        }*/

        return 0; // Convert.ToByte(output);
    }

    private string convert(byte input, short bitLength)
    {
        return Convert.ToString(input, 2).PadLeft(bitLength, '0');
    }
}