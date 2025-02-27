using System.Drawing;
using System.Drawing.Imaging;
using Logic.Extensions;
using SkiaSharp;
namespace Logic;

[System.Runtime.Versioning.SupportedOSPlatform( "windows" )]
static public class ScreenCapturer
{
      #region ___F I E L D S___ 
      private static readonly int
              _windowHeaderHeight = 42,
              _fontSize = 64;
      private static string
              _outputDirectory_DEFAULT = "Output",
              _outputDirectory = string.Empty;
      private static Size
              _charSize = new( _fontSize - 1 , (_fontSize * 2) - 2 );
      #endregion

      #region ___P R O P E R T I E S___ 
      public static string OutputDirectory
      {
            get => _outputDirectory != string.Empty ? _outputDirectory : _outputDirectory_DEFAULT;

            internal set
            {
                  string res = value != string.Empty ? value : _outputDirectory_DEFAULT;
                  if(!Directory.Exists( res ))
                  {
                        Directory.CreateDirectory( res );
                        Console.WriteLine( $"Created new Directory \'{res}\'" );
                  }
                  _outputDirectory = Path.Combine( res );
            }
      }
      public static Size CharSize { get => _charSize; set => _charSize = value; }
      #endregion

      #region ___I N T E R N A L   M E T H O D S___ 
      /// <summary>
      /// Captures a Region on the Screen as .png in the output-directory
      /// </summary>
      ///
      /// <param name="width" > screenshot dimension in pixel </param>
      /// <param name="height"> screenshot dimension in pixel </param>
      /// <param name="wOffset" > offset in pixel </param>
      /// <param name="hOffset"> offset in pixel </param>
      internal static Bitmap? CaptureRegion( int width , int height , int wOffset = 0 , int hOffset = 0 )
      {
            Bitmap? res = default;
            try
            {
                  using Bitmap bitmap = Capture( width , height , wOffset , hOffset );
                  string timestamp = DateTime.Now.ToString( "yyyy-MM-dd_HHmmss_fff" );
                  res = bitmap;

                  string filePath = Path.Combine( OutputDirectory , $"capture_{timestamp}.png" );
                  bitmap.Save( filePath , ImageFormat.Png );
            }
            catch(Exception ex) { Console.WriteLine( $"Error capturing screen: {ex.Message}" ); }
            return res;
      }
      internal static Bitmap Capture( int width , int height , int wOffset , int hOffset )
      {
            Bitmap res = new( width , height );

            using Graphics graphics = Graphics.FromImage( res );

            graphics.CopyFromScreen(
                wOffset ,
                _windowHeaderHeight + hOffset ,
                0 ,
                0 ,
                new Size( width , height )
            );
            return res;
      }
      internal static void CaptureSquareRegion( int width , int height , int wOffset = 0 , int hOffset = 0 , string backgroundColorName = "" )
      {
            using Bitmap? captured = new( width , height );
            try
            {
                  using Bitmap bitmap = Capture( width , height , wOffset , hOffset );
                  string timestamp = DateTime.Now.ToString( "yyyy-MM-dd_HHmmss_fff" );
                  string filePath = Path.Combine( OutputDirectory , $"capture_{timestamp}.png" );
                  bitmap.Save( filePath , ImageFormat.Png );
            }
            catch(Exception ex) { Console.WriteLine( $"Error capturing screen: {ex.Message}" ); }
            // Determine smallest square size
            int squareSize = Math.Max( width , height );
            // Create new square bitmap with background color
            using(Bitmap squareBitmap = new( squareSize , squareSize ))
            {
                  using(Graphics squareGraphics = Graphics.FromImage( squareBitmap ))
                  { // Set background color
                        Color backgroundColor;
                        try
                        {
                              backgroundColor = Color.FromName( backgroundColorName );
                              if(backgroundColor.A == 0 && backgroundColor.R == 0 && backgroundColor.G == 0 && backgroundColor.B == 0)
                                    backgroundColor = Color.Gray; // Fallback if color name not recognized
                        }
                        // Fallback for invalid color names
                        catch { backgroundColor = Color.Gray; }
                        squareGraphics.Clear( backgroundColor );
                        // Center the captured image
                        int xOffset = (squareSize - width) / 2;
                        int yOffset = (squareSize - height) / 2;
                        squareGraphics.DrawImage( captured , xOffset , yOffset );
                  } // Save the squared image
                  string timestamp = DateTime.Now.ToString( "yyyyMMdd_HHmmss_fff" );
                  string filePath = Path.Combine( "SquareSamples" , $"square_capture_{timestamp}.png" );
                  squareBitmap.Save( filePath , ImageFormat.Png );
            }
      }

      internal static Bitmap Capture( int width , int height )
            => Capture( width , height , 0 , 0 );
      internal static Bitmap? CaptureRegion( Size size )
            => CaptureRegion( size.Width , size.Height );
      internal static Bitmap? CaptureRegion( Size size , int widthOffset = 0 , int heightOffset = 0 )
            => CaptureRegion( size.Width , size.Height , widthOffset , heightOffset );
      internal static Bitmap? CaptureFirstCharOnConsole( )
            => CaptureRegion( CharSize );
      internal static Bitmap? CaptureCharAtCursorPosition( int x , int y )
            => CaptureRegion( CharSize , x * CharSize.Width , y * CharSize.Height );
      internal static Bitmap? CaptureFirstThreeXThreeCharsOnConsole( )
            => CaptureRegion( new Size( (CharSize.Width * 3) - (1 * 3) , (CharSize.Height * 3) - (6 * 3) ) );
      internal static Bitmap? CaptureFirstFiveXFiveCharsOnConsole( )
            => CaptureRegion( new Size( (CharSize.Width * 5) - (1 * 5) , (CharSize.Height * 5) - (6 * 5) ) );
      #endregion

      #region PRINTER SUBCLASS
      public static class Printer
      {
            #region ___P U B L I C   M E T H O D S___ 
            public static void CreateNewTestScreensSampleSet_Of( char toPrint )
            {
                  Console.OutputEncoding = System.Text.Encoding.UTF8;
                  Console.CursorVisible = false;

                  Console.Clear( );

                  foreach(KeyValuePair<string , string> a in StaticTestScreens_DEFAULT)
                  {
                        Console.WriteLine( a.Value );
                        if(a.Key.Contains( "THISCHAR" ))
                        {
                              Console.SetCursorPosition( 2 , 2 );
                              Console.Write( toPrint.ToString( ).ForegroundColor( RandomColor( ) ).BackgroundColor( RandomColor( ) ) );
                              Thread.Sleep( 100 );
                              ScreenCapturer.CaptureFirstFiveXFiveCharsOnConsole( );
                        }
                        ///     else if(a.Key.Contains( "3x3DEFAULT" ))
                        ///     {
                        ///           Console.SetCursorPosition( 1 , 1 );
                        ///           Console.Write( toPrint.ToString( ).ForegroundColor( RandomColor( ) ).BackgroundColor( RandomColor( ) ) );
                        ///           Thread.Sleep( 100 );
                        ///           ScreenCapturer.CaptureFirstThreeXThreeCharsOnConsole( );
                        ///     }
                        ///else
                        ///{
                        ///      //Thread.Sleep( 100 );
                        ///      //ScreenCapturer.CaptureFirstCharOnConsole( );
                        ///}

                        Console.Clear( );
                  }

                  string RandomColor( )
                  {
                        string res = "";
                        Random r = new( );

                        for(int i = 0 ; i < 3 ; i++)
                        {
                              int v = r.Next( 0 , 255 );
                              res += $"{v}";
                              if(i < 2) res += ";";
                        }
                        return res;
                  }
            }
            public static void CreateNewTestScreensSampleSet_DEFAULT( bool squared = false )
            {
                  Console.OutputEncoding = System.Text.Encoding.UTF8;

                  Console.WriteLine( "press enter to start" );
                  Console.ReadLine( );
                  Console.Clear( );

                  foreach(KeyValuePair<string , string> a in StaticTestScreens_DEFAULT)
                  {
                        Console.WriteLine( a.Value );
                        Thread.Sleep( 100 );


                        if(a.Key.Contains( "3x3" ))
                              CaptureFirstThreeXThreeCharsOnConsole( );

                        else if(a.Key.Contains( "5x5" ))
                              ScreenCapturer.CaptureFirstFiveXFiveCharsOnConsole( );
                        else
                              ScreenCapturer.CaptureFirstCharOnConsole( );

                        Thread.Sleep( 100 );
                        Console.Clear( );
                  }
                  Console.WriteLine( "\nSamples saved to Output directory".ForegroundColor( "green" ) );
                  Console.ReadLine( );
            }
            public static void CreateNewTestScreensSampleSet_DEFAULT_SQUARED( ) => CreateNewTestScreensSampleSet_DEFAULT( squared: true );
            #endregion

            #region ___F I E L D S___ 
            internal static readonly Dictionary<string , string> StaticColors_DEFAULT = new( )
                {
                        ///  { // develoment - copy/paste - template
                        ///           " devTemplate ",
                        ///           "0;0;0"
                        ///  },
                        {
                                "DEFAULT",
                                "0;0;0"
                        },
                        {
                                "black",
                                "0;0;0"
                        },
                        {
                                "white",
                                "255;255;255"
                        },
                        {
                                "red",
                                "255;0;0"
                        },
                        {
                                "green",
                                "0;255;0"
                        },
                        {
                                "blue",
                                "0;0;255"
                        },
                        {
                                "gray",
                                "128;128;128"
                        },
                        {
                                "yellow",
                                "255;255;0"
                        },
                        {
                                "cyan",
                                "0;255;255"
                        },
                        {
                                "magenta",
                                "255;0;255"
                        },
                };
            internal static readonly Dictionary<string , string> StaticTestScreens_DEFAULT = new( )
            {
                  ///  { // develoment - copy/paste - template
                        ///           " devTemplate ",
                        ///           "   "
                        ///  },
                  {
                                "DEFAULT",
                                "+"
                        },
                  {
                                "1x1",
                                "█"
                        },
                  {
                                "1x1DEFAULT",
                                "+"
                        },
                  {
                                "3x3",

                                   "012"
                                +"\n345"
                                +"\n678"

                        },
                  {
                                "3x3DEFAULT",
                                   "█▓░"
                                +"\n▒+▒"
                                +"\n░▓█"
                        },
                  {
                                "3x3COORDS",
                                   "⊙₁₂"
                                +"\n₁  "
                                +"\n₂  "
                        },
                  {
                                "3x3MEASURE",
                                   "  ┬"
                                +"\n  ³"
                                +"\n├³┼"
                        },
                  {
                                "3x3COORDS&MEASURE",
                                   "⊙₁╷"
                                +"\n₁ ³"
                                +"\n╶³┼"
                        },
                  {
                                "5x5COORDS",
                                   "⊙₁₂₃₄"
                                +"\n₁    "
                                +"\n₂ █  "
                                +"\n₃    "
                                +"\n₄    "
                        },
                  {
                                "5x5MEASURE",
                                   "    ┯"
                                +"\n    │"
                                +"\n  █ ⁵"
                                +"\n    │"
                                +"\n┠─⁵─╆"
                        },
                  {
                                "5x5CORDS&MEASURE",
                                   "⊙₁₂₃₄"
                                +"\n₁   ╿"
                                +"\n₂ █ ⁵"
                                +"\n₃   │"
                                +"\n₄╾⁵─╆"
                        },
                  {
                                "5x5FULL",
                                   "⊙₁₂₃₄"
                                +"\n₁╲N▖╿"
                                +"\n₂W╳E⁵"
                                +"\n₃▞S▟│"
                                +"\n₄╾⁵─╆"
                        },

                  {
                        "5x5CHARTEST",
                        string.Concat(

                              "⊙₁₂₃₄"       ,"\n",
                              "₁╲N▖╿"       ,"\n",
                              "₂W╳E⁵"       ,"\n",
                              "₃▞S▟│"       ,"\n",
                              "₄╾⁵─╆"

                        )
                  },
                  {
                        "5x5EMPTY",
                        string.Concat(

                              "⊙₁₂₃₄"       ,"\n",
                              "₁   ╿"       ,"\n",
                              "₂   ⁵"       ,"\n",
                              "₃   │"       ,"\n",
                              "₄╾⁵─╆"

                        )
                  },
                  {
                        "THISCHAR",
                        string.Concat(

                              "⊙₁₂₃₄"       ,"\n",
                              "₁   ╿"       ,"\n",
                              "₂   ⁵"       ,"\n",
                              "₃   │"       ,"\n",
                              "₄╾⁵─╆"

                        )
                  },
            };
            #endregion
      }
      #endregion
}