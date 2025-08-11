using System;

namespace Betriebsmodi.Models;

public class BlockControlModel
{
    public byte Character { get; set; }
    public byte IV { get; set; }
    public byte InterimResult { get; set; }
    public byte Key { get; set; }
    public byte Cipher { get; set; }
    public byte Output { get; set; }

    public BlockControlModel(char characterN, char keyN, bool requiresIV)
    {
        Character = (byte)(characterN - 64);
        Key = (byte)(keyN - 64);

        if (requiresIV) generateIV();
    }

    private void generateIV()
    {
        Random rand = new Random();
        IV = (byte)rand.Next(63);
    }
}