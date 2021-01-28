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
        private const int STD_OUTPUT_HANDLE = -11;
        private const int ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        private const int MF_BYCOMMAND = 0x0000;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int handle);
        // https://docs.microsoft.com/en-us/windows/console/getstdhandle

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();
        // https://docs.microsoft.com/en-us/windows/console/getconsolewindow

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr handle, out int mode);
        // https://docs.microsoft.com/en-us/windows/console/getconsolemode

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        // https://docs.microsoft.com/en-us/windows/console/setconsolemode

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmenu

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-deletemenu

        private static IntPtr stdHwnd = IntPtr.Zero;
        private static IntPtr consoleHwnd = IntPtr.Zero;
        private static IntPtr systemMenu = IntPtr.Zero;

        static WinApi()
        {
            stdHwnd = GetStdHandle(STD_OUTPUT_HANDLE);
            consoleHwnd = GetConsoleWindow();

            if (consoleHwnd != IntPtr.Zero)
            {
                systemMenu = GetSystemMenu(consoleHwnd, false);
            }
        }

        public static bool IsSupportedPlatform()
        {
            int win10_2015_11 = 14393;
            return Environment.OSVersion.Version.Build >= win10_2015_11;
        }

        public static void EnableVT100Codes()
        {
            if (stdHwnd == IntPtr.Zero)
            {
                return;
            }

            int mode;
            GetConsoleMode(stdHwnd, out mode);

            // requires windows 10 anniversary update
            SetConsoleMode(stdHwnd, mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);
        }

        public static void SetConsoleSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        public static void DisableMenuItem(SystemMenuItem item)
        {
            if (systemMenu != IntPtr.Zero)
            {
                DeleteMenu(systemMenu, (int)item, MF_BYCOMMAND);
            }
        }
    }
}
