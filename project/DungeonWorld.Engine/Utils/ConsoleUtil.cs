using System;

namespace DungeonWorld.Engine.Utils
{
    public class RGB
    {
        public byte R;
        public byte G;
        public byte B;

        public RGB(byte r = 255, byte g = 255, byte b = 255)
        {
            R = r;
            G = g;
            B = b;
        }
    }

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

    public static class ConsoleUtil
    {
        static string GetFormattedString(string text, TextStyles style = default, RGB cb = null, RGB cf = null)
        {
            string result = "";

            // set styling
            result += $"\x1B[{(int)style}m";

            // set front color
            if (cb != null)
            {
                result += $"\x1b[48;2;{cb.R};{cb.G};{cb.B}m";
            }

            // set back color
            if (cf != null)
            {
                result += $"\x1b[38;2;{cf.R};{cf.G};{cf.B}m";
            }

            return result + text;
        }

        public static void ResetStyling()
        {
            Console.Write(GetFormattedString("", TextStyles.None, new RGB(0, 0, 0), new RGB(255, 255, 255)));
        }

        public static void Write(string text, TextStyles style = default, RGB colorBack = null, RGB colorFront = null)
        {
            Console.Write(GetFormattedString(text, style, colorBack, colorFront));
        }

        public static void WriteLine(string text, TextStyles style = default, RGB colorBack = null, RGB colorFront = null)
        {
            Console.WriteLine(GetFormattedString(text, style, colorBack, colorFront));
        }
    }
}
