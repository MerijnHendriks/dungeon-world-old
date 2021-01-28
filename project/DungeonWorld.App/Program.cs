using System;
using DungeonWorld.Engine.Models;
using DungeonWorld.Engine.Utils;
using DungeonWorld.Core.Utils;

namespace DungeonWorld.App
{
    static class Program
    {
        static Program()
        {
            if (!WinApi.IsSupportedPlatform())
            {
                Console.WriteLine("Windows versions older than Windows 10 Anniversary update are not supported.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            WinApi.EnableVT100Codes();
            WinApi.DisableMenuItem(SystemMenuItem.SC_MINIMIZE);
            WinApi.DisableMenuItem(SystemMenuItem.SC_MAXIMIZE);
            WinApi.DisableMenuItem(SystemMenuItem.SC_SIZE);
            WinApi.SetConsoleSize(120, 30);
        }

        static void Main(string[] args)
        {
            TextStyle style = new TextStyle("#c8c864", "#64643c", TextStyles.Underlined);
            Box border = new Box(10, 5, 50, 20);
            Coord text1 = new Coord(20, 20);
            Coord text2 = new Coord(20, 21);

            ConsoleUtil.WriteBorder(border);
            ConsoleUtil.WritePosition("Hello World!", text1, style);
            ConsoleUtil.WritePosition($"{DiceUtil.GetResult()}", text2, style);
            Console.ReadKey();
        }
    }
}
