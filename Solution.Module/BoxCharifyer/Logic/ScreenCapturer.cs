using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

using SkiaSharp;

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
                        string timestamp = DateTime.Now.ToString( "yyyyMMdd_HHmmss" );
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
        public static void CaptureCharAtCursorPosition( int x , int y ) => CaptureRegion( CharSize , x * CharSize.Width , y * CharSize.Height );
        #endregion
}
