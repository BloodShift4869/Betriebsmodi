using System;
using Betriebsmodi.Models;

namespace Betriebsmodi.ViewModels;

public partial class BlockControlViewModel : ViewModelBase
{
    public char CharacterN => _model.CharacterN;
    public byte KeyN => _model.KeyN;
    
    public string CharacterString { get; }
    public string KeyString { get; }
    
    private BlockControlModel _model;

    public BlockControlViewModel(char characterN, char keyN)
    {
        _model = new BlockControlModel(characterN, keyN);
        
        CharacterString = Convert.ToString(_model.Character, 2).PadLeft(6, '0');
        KeyString = Convert.ToString(_model.KeyN, 2).PadLeft(6, '0');
    }
}