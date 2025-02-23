using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

using SkiaSharp;
using Logic.Extensions;

namespace Logic;

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

        #region ___P U B L I C   M E T H O D S___ 
        /// <summary>
        /// 
        /// </summary>
        ///
        /// <param name="outputDirectory"></param>
        /// <param name="width" > screenshot dimension in pixel </param>
        /// <param name="height"> screenshot dimension in pixel </param>
        /// <param name="wOffset" > offset in pixel </param>
        /// <param name="hOffset"> offset in pixel </param>
        [System.Runtime.Versioning.SupportedOSPlatform( "windows" )]
        public static void CaptureRegion( int width , int height , int wOffset = 0 , int hOffset = 0 )
        {
                try
                {
                        using Bitmap bitmap = new( width , height );

                        using(Graphics graphics = Graphics.FromImage( bitmap ))
                        {
                                graphics.CopyFromScreen(
                                    wOffset ,
                                    hOffset + _windowHeaderHeight ,
                                    0 ,
                                    0 ,
                                    new Size( width , height )
                                );
                        }
                        string timestamp = DateTime.Now.ToString( "yyyy-MM-dd_HHmmss_fff" );
                        string filePath = Path.Combine( OutputDirectory , $"capture_{timestamp}.png" );
                        bitmap.Save( filePath , ImageFormat.Png );
                }
                catch(Exception ex) { Console.WriteLine( $"Error capturing screen: {ex.Message}" ); }
        }

        [System.Runtime.Versioning.SupportedOSPlatform( "windows" )]
        public static void CaptureRegion( Size size ) => CaptureRegion( size.Width , size.Height );
        [System.Runtime.Versioning.SupportedOSPlatform( "windows" )]
        public static void CaptureRegion( Size size , int widthOffset = 0 , int heightOffset = 0 ) => CaptureRegion( size.Width , size.Height , widthOffset , heightOffset );
        [System.Runtime.Versioning.SupportedOSPlatform( "windows" )]
        public static void CaptureFirstThreeXThreeCharsOnConsole( ) => CaptureRegion( new Size( (CharSize.Width * 3) - (1 * 3) , (CharSize.Height * 3) - (6 * 3) ) );
        [System.Runtime.Versioning.SupportedOSPlatform( "windows" )]
        public static void CaptureFirstCharOnConsole( ) => CaptureRegion( CharSize );
        [System.Runtime.Versioning.SupportedOSPlatform( "windows" )]
        public static void CaptureFirstFiveXFiveCharsOnConsole( ) => CaptureRegion( new Size( (CharSize.Width * 5) - (1 * 5) , (CharSize.Height * 5) - (6 * 5) ) );
        [System.Runtime.Versioning.SupportedOSPlatform( "windows" )]
        public static void CaptureCharAtCursorPosition( int x , int y ) => CaptureRegion( CharSize , x * CharSize.Width , y * CharSize.Height );
        #endregion

        #region PRINTER SUBCLASS
        public static class Printer
        {
                public static void CreateNewTestScreensSampleSet_DEFAULT( )
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
                                        ScreenCapturer.CaptureFirstThreeXThreeCharsOnConsole( );
                                if(a.Key.Contains( "5x5" ))
                                        ScreenCapturer.CaptureFirstFiveXFiveCharsOnConsole();
                                Thread.Sleep( 100 );
                                //Console.ReadLine( );
                                Console.Clear( );
                        }
                        Console.WriteLine( "\nSamples saved to Output directory".ForegroundColor( "green" ) );
                        Console.ReadLine( );
                }

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
                        "0"
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
                };
        }
        #endregion
}
