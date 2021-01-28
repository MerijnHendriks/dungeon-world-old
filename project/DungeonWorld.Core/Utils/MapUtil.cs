using DungeonWorld.Engine.Utils;
using DungeonWorld.Engine.Models;
using DungeonWorld.Core.Models;

namespace DungeonWorld.Core.Utils
{
    public static class MapUtil
    {
        public static bool Intersects(Map map, int x, int y)
        {
            return map.Colliders[y, x];
        }

        public static bool Intersects(Map map, Position position)
        {
            return Intersects(map, position.Y, position.X);
        }

        public static void DrawMap(Map map, int x, int y, int width, int height)
        {
            for (int i = y; i < height; i++)
            {
                for (int j = x; i < width; j++)
                {
                    ConsoleUtil.Write(map.Visuals.Text[i, j], map.Visuals.Colors[i, j]);
                }
            }
        }

        public static void DrawMap(Map map, Box box)
        {
            DrawMap(map, box.X, box.Y, box.Width, box.Height);
        }
    }
}
