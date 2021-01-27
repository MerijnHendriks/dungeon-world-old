using System;

namespace DungeonWorld.Engine.Utils
{
    public enum TextStyles
    {
        None = 0,
        Bold,
        Faint,
        Italic,
        Underlined,
        Inverse,
        Strikethrough
    }

    public class RGB
    {
        public byte Red;
        public byte Green;
        public byte Blue;

        public RGB()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
        }

        public RGB(byte r, byte g, byte b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }
    }

    public class TextStyle
    {
        public RGB ColorFront;
        public RGB ColorBack;
        public TextStyles Style;

        public TextStyle()
        {
            ColorFront = new RGB();
            ColorBack = new RGB(255, 255, 255);
            Style = TextStyles.None;
        }

        public TextStyle(RGB colorFront, RGB colorBack, TextStyles style)
        {
            ColorFront = colorFront;
            ColorBack = colorBack;
            Style = style;
        }
    }

    public class BorderStyle
    {
        public string Horizontal;
        public string Vertical;
        public string LeftTop;
        public string LeftBottom;
        public string RightTop;
        public string RightBottom;

        public BorderStyle()
        {
            Horizontal = "─";
            Vertical = "│";
            LeftTop = "┌";
            LeftBottom = "└";
            RightTop = "┐";
            RightBottom = "┘";
        }

        public BorderStyle(string horizontal, string vertical, string leftTop, string leftBottom, string rightTop, string rightBottom)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            LeftTop = leftTop;
            LeftBottom = leftBottom;
            RightTop = rightTop;
            RightBottom = rightBottom;
        }
    }

    public static class ConsoleUtil
    {
        static string GetFormattedString(string text, TextStyle style = null)
        {
            string result = "";

            // set default if none is defined
            if (style == null)
            {
                return text;
            }

            // set styling
            result += $"\x1b[{(int)style.Style}m";

            // set front color
            if (style.ColorBack != null)
            {
                result += $"\x1b[48;2;{style.ColorBack.Red};{style.ColorBack.Green};{style.ColorBack.Blue}m";
            }

            // set back color
            if (style.ColorFront != null)
            {
                result += $"\x1b[38;2;{style.ColorFront.Red};{style.ColorFront.Green};{style.ColorFront.Blue}m";
            }

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

        public static void WriteBorder(int x, int y, int width, int height, BorderStyle border = null, TextStyle style = null)
        {
            // use default if no border style is specified
            if (border == null)
            {
                border = new BorderStyle();
            }

            // draw border edges
            for (int i = x; i < width - x + 1; i++)
            {
                WritePosition(border.Horizontal, i, y, style);
                WritePosition(border.Horizontal, i, height, style);
            }

            for (int i = y; i < height - y + 1; i++)
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
    }
}
