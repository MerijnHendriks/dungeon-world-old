using System;
using DungeonWorld.Engine.Utils;
using DungeonWorld.Engine.Systems;
using DungeonWorld.App.Commands;
using DungeonWorld.App.Views;

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
            // add systems
            SystemManager.Add<CommandSystem>();
            SystemManager.Add<ViewSystem>();

            // add commands
            CommandSystem commands = SystemManager.Get<CommandSystem>();
            commands.Add<ExitCommand>();

            // add views
            ViewSystem views = SystemManager.Get<ViewSystem>();
            views.Add<TestView>();

            // show test
            SystemManager.Get<ViewSystem>().SetView<TestView>();

            // app loop
            while (!commands.Get<ExitCommand>().Executing)
            {
                SystemManager.OnUpdate();
            }
        }
    }
}
