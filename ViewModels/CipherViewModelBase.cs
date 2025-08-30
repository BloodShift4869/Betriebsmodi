using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Betriebsmodi.Models;

namespace Betriebsmodi.ViewModels;

public abstract class CipherViewModelBase : ViewModelBase
{
    public char CharacterN { get; set; }
    public string CharacterString { get; set; }
    public string KeyString { get; set; }
    public char Result { get; set; }
    public ObservableCollection<string> CipherString { get; set; } = new();
    public ObservableCollection<string> OutputString { get; set; } = new();
    
    public string _CipherString { get; set; }
    public string _OutputString { get; set; }

    protected BlockModel _model;
    
    protected abstract void ExecuteCipher();
    protected abstract void PlaceholderSetup(short bitLength);

    public abstract Task StartAnimation(int speed);

    protected async Task RevealBits(ObservableCollection<string> animationItem, string source, int speed = 300)
    {
        for (int i = 0; i < source.Length; i++) 
        {
            animationItem[i] = source[i].ToString(); 
            await Task.Delay(speed);
        }
    }
    
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