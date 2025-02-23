using Logic;
using Logic.Structs;

using SC = Logic.ScreenCapturer;

namespace ConApp;

internal class Program
{
        static void Main( )
        {
                //Logic.Structs.TChar.PrintAllBoxChars( );
                Console.ReadLine( );
                Console.Clear( );

                Console.Write( "╫" ); // Example character

                ScreenCapturer.CaptureFirstCharOnConsole( );

                Console.ReadLine( );

                Console.Clear( );


                Console.Write( "H▒Y\n▞─▚\nB█X" );
                Thread.Sleep( 1500 );
                ScreenCapturer.CaptureFirstThreeXThreeCharsOnConsole( );
                Console.ReadLine( );
                Console.Clear( );

                Console.Write(
                        string.Join(

                                "H▒Y"
                                        , "\n" ,
                                "▞─▚"
                                        , "\n" ,
                                "B█X"
                       ) );

                Thread.Sleep( 1500 );
                ScreenCapturer.CaptureFirstThreeXThreeCharsOnConsole( );
                Console.ReadLine( );
                Console.Clear( );

                Console.WriteLine( "\nScreenshot saved to Output directory" );

                Console.ReadLine( );

        }
}
