namespace DungeonWorld.Core.Models
{
    public class MapBase
    {
        public string Name;
        public int Width;
        public int Height;

        public MapBase(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }
    }
}
