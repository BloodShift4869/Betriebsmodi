using System;

namespace Betriebsmodi.Models;

public class BlockModel
{
    public byte Character { get; set; }
    public byte Nonce { get; set; }
    public byte InterimResult { get; set; }
    public byte Key { get; set; }
    public byte Cipher { get; set; }
    public byte Output { get; set; }

    public BlockModel(char characterN, byte key, bool requiresNonce)
    {
        Character = (byte)(characterN - 64);
        Key = key;

        if (requiresNonce) generateNonce();
    }
    
    public BlockModel(char characterN, byte key, byte nonce)
    {
        Character = (byte)(characterN - 64);
        Key = key;
        Nonce = nonce;
    }

    private void generateNonce()
    {
        Random rand = new Random();
        Nonce = (byte)rand.Next(63);
    }
}