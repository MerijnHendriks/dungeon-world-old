using System;
using DungeonWorld.Engine.Models;

namespace DungeonWorld.Engine.Utils
{
    public class CollisionUtil
    {
        public static bool Interects(Box a, Box b)
        {
            return ((a.X < b.X + b.Width) && (a.X + a.Width > b.X) && (a.Y < b.Y + b.Height) && (a.Y + a.Height > b.Y));
        }

        public static bool Interects(Circle a, Circle b)
        {
            int dx = b.X - a.X;
            int dy = b.Y - a.Y;
            int distance = (dx * dx) + (dy * dy);

            return (distance < a.Radius + b.Radius);
        }

        public static bool Interects(Box a, Circle b)
        {
            int dx = b.X - Math.Clamp(b.X, a.X, a.Width);
            int dy = b.Y - Math.Clamp(b.Y, a.Y, a.Height);
            int distance = (dx * dx) + (dy * dy);

            return (distance < b.Radius * b.Radius);
        }
    }
}
