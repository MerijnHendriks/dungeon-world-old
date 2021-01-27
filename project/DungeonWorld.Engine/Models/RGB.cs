using System.Globalization;

namespace DungeonWorld.Engine.Models
{
    public class RGB
    {
        public byte Red;
        public byte Green;
        public byte Blue;

        public RGB(byte r, byte g, byte b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public RGB(string hex)
        {
            hex = hex.Replace("#", "");
            Red = byte.Parse(hex.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            Green = byte.Parse(hex.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            Blue = byte.Parse(hex.Substring(4, 2), NumberStyles.AllowHexSpecifier);
        }
    }
}
