using System;
using Betriebsmodi.Models;

namespace Betriebsmodi.ViewModels;

public abstract class CipherViewModelBase : ViewModelBase
{
    public char CharacterN { get; set; }
    public string CharacterString { get; set; }
    public string KeyString { get; set; }
    public string CipherString { get; set; }
    public string OutputString { get; set; }
    public static string Result { get; set; } = string.Empty;

    protected BlockModel _model;
    
    protected abstract void ExecuteCipher();
    
    protected byte CalculateXOr(byte a, byte b)
    {
        return (byte)(a ^ b);
    }

    protected byte Permutate(byte c)
    {
        int[] pbox = { 3, 2, 0, 5, 1, 4 };
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

    protected string ConvertToString(byte input, short bitLength)
    {
        return Convert.ToString(input, 2).PadLeft(bitLength, '0');
    }
}