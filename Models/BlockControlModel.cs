namespace Betriebsmodi.Models;

public class BlockControlModel
{
    public byte Character { get; set; }
    public byte Key { get; set; }
    public byte Cipher { get; set; }
    public byte Output { get; set; }

    public BlockControlModel(char characterN, char keyN)
    {
        Character = (byte)(characterN - 64);
        Key = (byte)(keyN - 64);
    }
}