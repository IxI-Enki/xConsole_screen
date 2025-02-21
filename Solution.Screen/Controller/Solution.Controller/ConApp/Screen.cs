using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
        public struct Screen
        {
                public Screen( )
                {
                        BufferWidth = Console.BufferWidth;
                        BufferHeight = Console.BufferHeight;
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                        WindowTop = Console.WindowTop;
                        WindowLeft = Console.WindowLeft;
                }

                #region ___P R O P E R T I E S___ 
                public int BufferWidth { get; internal set; }
                public int BufferHeight { get; internal set; }
                public int WindowWidth { get; internal set; }
                public int WindowHeight { get; internal set; }
                public int WindowTop { get; internal set; }
                public int WindowLeft { get; internal set; }

                public readonly Size BufferSize => new( BufferWidth , BufferHeight );
                public readonly Size WindowSize => new( WindowWidth , WindowHeight );
                public readonly Point WindowStartpoint => new( WindowLeft , WindowTop );
                #endregion
        }

        public static class ScreenExtensions
        {
                public static void Print( this Screen s )
                {
                        Console.SetCursorPosition( 3 , s.WindowHeight - 1 );
                        Console.Write( s.WindowSize );
                }


                public static void PrintBorder( this Screen s )
                {
                        if(s.WindowHeight > 2 && s.WindowWidth > 2)
                        {
#if DEBUG
                                List<string>? lines = [];

                                for(int i = 0 ; i < s.WindowHeight ; i++)
                                {
                                        string newLine = i == 0 ? "┌" : i == s.WindowHeight - 1 ? "└" : "│";

                                        for(int j = 0 ; j < s.WindowWidth - 1 ; j++)
                                        {
                                                if(j == 0)
                                                        newLine += "";
                                                else if(j == s.WindowWidth - 2)
                                                        newLine += i == 0 ? "┐" : i == s.WindowHeight - 1 ? "┘" : "│";
                                                else
                                                        newLine += i == 0 || i == s.WindowHeight - 1 ? "─" : " ";
                                        }
                                        newLine += i < s.WindowHeight - 1 ? "\n" : "";
                                        lines.Add( newLine );
                                }
                                foreach(var x in lines) Console.Write( $"\u001b[48;2;17;14;22m\u001b[38;2;130;30;30m{x}" );

                                if(s.WindowHeight > 2 && s.WindowWidth > 23) Print( s );

                                Console.Write( "\u001b[38;2;200;0;0m" );

                                Console.SetCursorPosition( 1 , 1 );
#endif 
                        }
                }

                //└┘─│┐└
                public static void Update( this Screen s )
                {
                        s.BufferWidth = Console.BufferWidth;
                        s.BufferHeight = Console.BufferHeight;
                        s.WindowWidth = Console.WindowWidth;
                        s.WindowHeight = Console.WindowHeight;
                        s.WindowTop = Console.WindowTop;
                        s.WindowLeft = Console.WindowLeft;
                }

                public static void Fill( this Screen s )
                {
#if DEBUG
                        List<string>? lines = [];

                        for(int i = 0 ; i < s.WindowHeight ; i++)
                        {
                                string newLine = string.Empty;

                                for(int j = 0 ; j < s.WindowWidth - 2 ; j++)
                                        newLine += "_";

                                newLine += @"\n";
                                lines.Add( newLine );
                        }
                        foreach(var x in lines) Console.Write( $"\u001b[38;2;40;140;80m{x}\u001b[0m" );
#endif
                }
        }
}
