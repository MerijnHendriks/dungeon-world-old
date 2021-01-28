using DungeonWorld.Engine.Models;

namespace DungeonWorld.Core.Models
{
    public class Map
    {
        public string Name;
        public int Width;
        public int Height;
        public bool[,] Colliders;
        public AsciiImage Visuals;

        public Map(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
            Colliders = new bool[height, width];
            Visuals = new AsciiImage(width, height);
        }
    }
}