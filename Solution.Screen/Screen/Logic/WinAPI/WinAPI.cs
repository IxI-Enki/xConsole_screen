using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WinAPI;

public static class ConsoleApi
{
        [DllImport( "kernel32.dll" , SetLastError = true )]
        public static extern nint GetStdHandle( int nStdHandle );
        public const int STD_OUTPUT_HANDLE = -11;

        [DllImport( "kernel32.dll" , SetLastError = true )]
        public static extern bool GetCurrentConsoleFont(
            nint hConsoleOutput ,
            bool bMaximumWindow ,
            ref CONSOLE_FONT_INFO lpConsoleCurrentFont );

        [DllImport( "kernel32.dll" , SetLastError = true )]
        public static extern COORD GetConsoleFontSize(
            nint hConsoleOutput ,
            int nFont );

        [DllImport( "kernel32.dll" , SetLastError = true )]
        public static extern bool SetCurrentConsoleFontEx(
            nint hConsoleOutput ,
            bool bMaximumWindow ,
            ref CONSOLE_FONT_INFOEX lpConsoleFont );

        [DllImport( "kernel32.dll" , SetLastError = true )]
        public static extern bool GetCurrentConsoleFontEx(
            nint hConsoleOutput ,
            bool bMaximumWindow ,
            ref CONSOLE_FONT_INFOEX lpConsoleFont );

        [StructLayout( LayoutKind.Sequential )]
        public struct COORD
        {
                public short X;
                public short Y;
        }

        [StructLayout( LayoutKind.Sequential )]
        public struct CONSOLE_FONT_INFO
        {
                public int nFont;
                public COORD dwFontSize;
        }

        [StructLayout( LayoutKind.Sequential , CharSet = CharSet.Unicode )]
        public struct CONSOLE_FONT_INFOEX
        {
                public int cbSize;
                public int nFont;
                public COORD dwFontSize;
                public int FontFamily;
                public int FontWeight;
                [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 32 )]
                public string FaceName;
        }
}
