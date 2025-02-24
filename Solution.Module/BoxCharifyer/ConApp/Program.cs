using Logic;
using Logic.Structs;
using SC = Logic.ScreenCapturer;

namespace ConApp;

internal class Program
{
      static void Main( )
      {
            //Logic.Structs.TChar.PrintAllBoxChars( );
            ///  Console.ReadLine( );
            ///  Console.Clear( );
            ///  Console.Write( "╫" ); // Example character
            ///
            ///  ScreenCapturer.CaptureFirstCharOnConsole( );
            ///
            ///  Console.ReadLine( );
            ///
            ///  Console.Clear( );
            ///
            ///
            ///  Console.Write( "H▒Y\n▞─▚\nB█X" );
            ///  Thread.Sleep( 1500 );
            ///  ScreenCapturer.CaptureFirstThreeXThreeCharsOnConsole( );
            ///  Console.ReadLine( );
            ///  Console.Clear( );
            ///
            ///  Console.Write(
            ///          string.Join(
            ///
            ///                  "H▒Y"
            ///                          , "\n" ,
            ///                  "▞─▚"
            ///                          , "\n" ,
            ///                  "B█X"
            ///         ) );
            ///
            ///  Thread.Sleep( 1500 );
            ///  ScreenCapturer.CaptureFirstThreeXThreeCharsOnConsole( );
            ///  Console.Clear( );

            //ScreenCapturer.Printer.CreateNewTestScreensSampleSet_DEFAULT( );
            //ScreenCapturer.Printer.CreateNewTestScreensSampleSet_Of( '╀' );
            //ScreenCapturer.Printer.CreateNewTestScreensSampleSet_DEFAULT_SQUARED( );

            string q = 
                  //TCharExtensions.ReturnAllBoxChars( );
                  AlphaNumeric();

            Console.WriteLine( "press enter to start" );
            Console.ReadLine( );

            int x = 25;

            for(int i = 0 ; i < x ; i++)
                  foreach(char c in q)
                        ScreenCapturer.Printer.CreateNewTestScreensSampleSet_Of( c );

            //Console.WriteLine(q );




            Console.ReadLine( );
      }

      private static string AlphaNumeric( )
            => "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyY üÜäÄöÖ1234567890 ";
}
