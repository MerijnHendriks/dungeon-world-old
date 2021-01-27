using System;
using DungeonWorld.Engine.Utils;

namespace DungeonWorld.App
{
    static class Program
    {
        static Program()
        {
            WinApi.SetConsoleSize(120, 30);
            WinApi.DeleteMenuButton(SystemMenuItem.SC_MINIMIZE);
            WinApi.DeleteMenuButton(SystemMenuItem.SC_MAXIMIZE);
            WinApi.DeleteMenuButton(SystemMenuItem.SC_SIZE);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
