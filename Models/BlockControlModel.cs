namespace Betriebsmodi.Models;

public class BlockControlModel
{
    public char CharacterN { get; set; }
    public byte Character { get; }
    public byte KeyN { get; set; }

    public BlockControlModel(char characterN, char keyN)
    {
        CharacterN = characterN;
        Character = (byte)(characterN - 64); 
        KeyN = (byte)(keyN - 64);
    }
}