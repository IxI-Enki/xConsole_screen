using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Structs
{

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

                        ///   // Update FontSize from Windows API
                        ///   IntPtr hConsole = ConsoleApi.GetStdHandle( ConsoleApi.STD_OUTPUT_HANDLE );
                        ///   ConsoleApi.CONSOLE_FONT_INFO fontInfo = new( );
                        ///   if(ConsoleApi.GetCurrentConsoleFont( hConsole , false , ref fontInfo ))
                        ///   {
                        ///           ConsoleApi.COORD fontSize = ConsoleApi.GetConsoleFontSize( hConsole , fontInfo.nFont );
                        ///           s.FontSize = fontSize.Y;
                        ///   }
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
                                //, $"FontSize        : {s.FontSize,23}"
                                ) );
                }
        }
}
