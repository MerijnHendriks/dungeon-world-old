using System;
using System.Runtime.InteropServices;

namespace DungeonWorld.Engine.Utils
{
    // https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand
    public enum SystemMenuItem
    {
        SC_CLOSE = 0xF060,
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_SIZE = 0xF000
    }

    public static class WinApi
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        static extern IntPtr GetConsoleWindow();
        // https://docs.microsoft.com/en-us/windows/console/getconsolewindow

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmenu


        [DllImport("user32.dll")]
        static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-deletemenu

        static IntPtr consoleHwnd = IntPtr.Zero;
        static IntPtr systemMenu = IntPtr.Zero;

        static WinApi()
        {
            consoleHwnd = GetConsoleWindow();

            if (consoleHwnd != IntPtr.Zero)
            {
                systemMenu = GetSystemMenu(consoleHwnd, false);
            }
        }

        public static void SetConsoleSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        public static void DeleteMenuButton(SystemMenuItem item)
        {
            int MF_BYCOMMAND = 0x00000000;

            if (systemMenu != IntPtr.Zero)
            {
                DeleteMenu(systemMenu, (int)item, MF_BYCOMMAND);
            }
        }
    }
}
