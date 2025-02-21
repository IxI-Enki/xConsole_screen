using Logic.WinAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Structs;

public struct Screen : IEquatable<Screen>
{
        #region ___P R O P E R T I E S___ 
        public int BufferWidth { get; set; }
        public int BufferHeight { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public int WindowTop { get; set; }
        public int WindowLeft { get; set; }
        public int FontSize { get; set; } // Font height in pixels

        public readonly Size BufferSize => new( BufferWidth , BufferHeight );
        public readonly Size WindowSize => new( WindowWidth , WindowHeight );
        public readonly Point WindowStartpoint => new( WindowLeft , WindowTop );
        #endregion

        #region ___C O N S T R U C T O R S___ 
        public Screen( )
        {
                BufferWidth = Console.BufferWidth;
                BufferHeight = Console.BufferHeight;

                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;

                WindowTop = Console.WindowTop;
                WindowLeft = Console.WindowLeft;

                // Get font size via Windows API
                IntPtr hConsole = ConsoleApi.GetStdHandle( ConsoleApi.STD_OUTPUT_HANDLE );
                ConsoleApi.CONSOLE_FONT_INFO fontInfo = new( );

                if(ConsoleApi.GetCurrentConsoleFont( hConsole , false , ref fontInfo ))
                {
                        ConsoleApi.COORD fontSize = ConsoleApi.GetConsoleFontSize( hConsole , fontInfo.nFont );
                        FontSize = fontSize.Y; // Y is the height in pixels
                }
                else
                {
                        FontSize = 16; // Fallback default
                }
        }

        public bool Equals( Screen other )
        {
                bool result = false;

                if(
                        BufferSize == other.BufferSize &&
                        WindowSize == other.WindowSize &&
                        WindowStartpoint == other.WindowStartpoint &&
                        FontSize == other.FontSize)

                        result = true;

                return result;
        }
        #endregion
}

public static class ScreenExtensions
{
        public static void Update( this Screen s )
        {
                s.BufferWidth = Console.BufferWidth;
                s.BufferHeight = Console.BufferHeight;

                s.WindowWidth = Console.WindowWidth;
                s.WindowHeight = Console.WindowHeight;

                s.WindowTop = Console.WindowTop;
                s.WindowLeft = Console.WindowLeft;

                // Update FontSize from Windows API
                IntPtr hConsole = ConsoleApi.GetStdHandle( ConsoleApi.STD_OUTPUT_HANDLE );
                ConsoleApi.CONSOLE_FONT_INFO fontInfo = new( );
                if(ConsoleApi.GetCurrentConsoleFont( hConsole , false , ref fontInfo ))
                {
                        ConsoleApi.COORD fontSize = ConsoleApi.GetConsoleFontSize( hConsole , fontInfo.nFont );
                        s.FontSize = fontSize.Y;
                }

        }

        public static void Display( this Screen s )
        {
                Console.Write
                        ( string.Join(
                                   $"Buffer Size     : {s.BufferSize,23}"
                                 , $"Buffer Width    : {s.BufferWidth,23}"
                                 , $"Buffer Height   : {s.BufferHeight,23}"
                                 , "\n"
                                 , $"Window Size     : {s.WindowSize,23}"
                                 , $"Window Width    : {s.WindowWidth,23}"
                                 , $"Window Height   : {s.WindowHeight,23}"
                                 , "\n"
                                 , $"Window StartPos : {s.WindowSize,23}"
                                 , $"Window Top      : {s.WindowTop,23}"
                                 , $"Window Left     : {s.WindowLeft,23}"
                                 , "\n"
                                 , $"FontSize        : {s.FontSize,23}"
                        ) );
        }
}