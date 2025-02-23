using Logic.WinAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Structs;

public struct Screen : IEqualityComparer<Screen>
{
        #region ___P R O P E R T I E S___ 
        public int BufferWidth { get; set; }
        public int BufferHeight { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public int WindowTop { get; set; }
        public int WindowLeft { get; set; }
        //public int FontSize { get; set; } // Font height in pixels

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

                ///    // Get font size via Windows API
                ///    IntPtr hConsole = ConsoleApi.GetStdHandle( ConsoleApi.STD_OUTPUT_HANDLE );
                ///    ConsoleApi.CONSOLE_FONT_INFO fontInfo = new( );
                ///
                ///    if(ConsoleApi.GetCurrentConsoleFont( hConsole , false , ref fontInfo ))
                ///    {
                ///            ConsoleApi.COORD fontSize = ConsoleApi.GetConsoleFontSize( hConsole , fontInfo.nFont );
                ///            FontSize = fontSize.Y; // Y is the height in pixels
                ///    }
                ///    else
                ///            FontSize = 16; // Fallback default
        }


        public readonly bool Equals( Screen x , Screen y )
        {
                bool result = false;
                if(
                       x.BufferSize == y.BufferSize &&
                       x.WindowSize == y.WindowSize &&
                       x.WindowStartpoint == y.WindowStartpoint
                        //&& FontSize == other.FontSize
                        )
                        result = true;
                return result;
        }

        public readonly int GetHashCode( [DisallowNull] Screen obj ) => 1;



        #endregion
}
