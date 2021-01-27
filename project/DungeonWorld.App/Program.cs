using System;
using DungeonWorld.Engine.Utils;

namespace DungeonWorld.App
{
    static class Program
    {
        static Program()
        {
            WinApi.SetConsoleSize(120, 30);
            WinApi.DisableMenuItem(SystemMenuItem.SC_MINIMIZE);
            WinApi.DisableMenuItem(SystemMenuItem.SC_MAXIMIZE);
            WinApi.DisableMenuItem(SystemMenuItem.SC_SIZE);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
