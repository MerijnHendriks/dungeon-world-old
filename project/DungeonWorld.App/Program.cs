using System;
using DungeonWorld.Engine.Utils;

namespace DungeonWorld.App
{
    static class Program
    {
        static Program()
        {
            if (!WinApi.IsSupportedPlatform())
            {
                Console.WriteLine("Windows version older than Windows 10 Anniversary update are not supported.");
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
            ConsoleUtil.WriteBorder(0, 0, 119, 29);
            ConsoleUtil.WritePosition("Hello World!", 20, 20);
            Console.ReadKey();
        }
    }
}
