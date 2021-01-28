using System;
using System.Globalization;
using DungeonWorld.Engine.Models;

namespace DungeonWorld.Engine.Utils
{
    public static class ConsoleUtil
    {
        static int[] GetRGB(string hex)
        {
            hex = hex.Replace("#", "");

            return new int[3]
            {
                byte.Parse(hex.Substring(0, 2), NumberStyles.AllowHexSpecifier),
                byte.Parse(hex.Substring(2, 2), NumberStyles.AllowHexSpecifier),
                byte.Parse(hex.Substring(4, 2), NumberStyles.AllowHexSpecifier)
            };
        }

        static string GetFormattedString(string text, TextStyle style = null)
        {
            string result = "";

            // set default if none is defined
            if (style == null)
            {
                return text;
            }

            result += $"\x1b[";

            // set back color
            if (!string.IsNullOrWhiteSpace(style.ColorFront))
            {
                int[] rgb = GetRGB(style.ColorFront);
                result += $";38;2;{rgb[0]};{rgb[1]};{rgb[2]}";
            }

            // set front color
            if (!string.IsNullOrWhiteSpace(style.ColorBack))
            {
                int[] rgb = GetRGB(style.ColorBack);
                result += $";48;2;{rgb[0]};{rgb[1]};{rgb[2]}";
            }

            // add style
            result += $";{(int)style.Style}m";

            // add text
            result += text;

            // reset color at eol
            if (style.ColorBack != null || style.ColorFront != null)
            {
                result += "\x1b[0m";
            }

            return result;
        }

        public static void Write(string text, TextStyle style = null)
        {
            Console.Write(GetFormattedString(text, style));
        }

        public static void WriteLine(string text, TextStyle style = null)
        {
            Console.WriteLine(GetFormattedString(text, style));
        }

        public static void WritePosition(string text, int x, int y, TextStyle style = null)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(GetFormattedString(text, style));
        }

        public static void WritePosition(string text, Coord position, TextStyle style = null)
        {
            WritePosition(text, position.X, position.Y, style);
        }

        public static void WriteBorder(int x, int y, int width, int height, BorderStyle border = null, TextStyle style = null)
        {
            // use default if no border style is specified
            if (border == null)
            {
                border = new BorderStyle();
            }

            // draw border edges
            for (int i = x; i < width; i++)
            {
                WritePosition(border.Horizontal, i, y, style);
                WritePosition(border.Horizontal, i, height, style);
            }

            for (int i = y; i < height; i++)
            {
                WritePosition(border.Vertical, x, i, style);
                WritePosition(border.Vertical, width, i, style);
            }

            // draw border corners
            WritePosition(border.LeftTop, x, y, style);
            WritePosition(border.LeftBottom, x, height, style);
            WritePosition(border.RightTop, width, y, style);
            WritePosition(border.RightBottom, width, height, style);
        }

        public static void WriteBorder(Box box, BorderStyle border = null, TextStyle style = null)
        {
            WriteBorder(box.X, box.Y, box.Width, box.Height, border, style);
        }

        public static int GetWidth()
        {
            return Console.WindowWidth;
        }

        public static int GetHeight()
        {
            return Console.WindowHeight;
        }
    }
}
