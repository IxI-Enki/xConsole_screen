using Logic.Args;
using Logic.Controller;
using Logic.Structs;

namespace ConApp;

internal class Program
{
        static void Main( string[] args )
        {

                // Define ANSI escape sequences - Styles
                string reset = "\u001B[0m";
                string bold = "\u001B[1m";
                string faint = "\u001B[2m";
                string italic = "\u001B[3m";
                string underline = "\u001B[4m";
                string blink = "\u001B[5m";
                string rapidBlink = "\u001B[6m";
                string inverse = "\u001B[7m";
                string strikethrough = "\u001B[9m";

                // Foreground Colors
                string blackFg = "\u001B[30m";
                string redFg = "\u001B[31m";
                string greenFg = "\u001B[32m";
                string yellowFg = "\u001B[33m";
                string blueFg = "\u001B[34m";
                string magentaFg = "\u001B[35m";
                string cyanFg = "\u001B[36m";
                string whiteFg = "\u001B[37m";

                // Background Colors
                string blackBg = "\u001B[40m";
                string redBg = "\u001B[41m";
                string greenBg = "\u001B[42m";
                string yellowBg = "\u001B[43m";
                string blueBg = "\u001B[44m";
                string magentaBg = "\u001B[45m";
                string cyanBg = "\u001B[46m";
                string whiteBg = "\u001B[47m";

     

                // Print examples
                Console.WriteLine( $"{underline}This is underlined text{reset}" );
                Console.WriteLine( $"{italic}This is italic (cursive) text{reset} (may not work in all terminals)" );
                Console.WriteLine( $"{bold}This is bold text{reset}" );
                Console.WriteLine( $"{redFg}Red text{reset}" );
                Console.WriteLine( $"{greenBg}Text on green background{reset}" );
                Console.WriteLine( $"{underline}{bold}{redFg}Underlined, bold, red text{reset}" );
                // Print examples for styles
                Console.WriteLine( $"{bold}This is bold text{reset}" );
                Console.WriteLine( $"{faint}This is faint (dim) text{reset}" );
                Console.WriteLine( $"{italic}This is italic (cursive) text{reset} (may not work in all terminals)" );
                Console.WriteLine( $"{underline}This is underlined text{reset}" );
                Console.WriteLine( $"{blink}This is blinking text{reset} (slow blink, terminal dependent)" );
                Console.WriteLine( $"{rapidBlink}This is rapid blinking text{reset} (less supported)" );
                Console.WriteLine( $"{inverse}This is inverse text{reset}" );
                Console.WriteLine( $"{strikethrough}This is strikethrough text{reset} (less common)" );

                // Print examples for foreground colors
                Console.WriteLine( $"{blackFg}Black text{reset}" );
                Console.WriteLine( $"{redFg}Red text{reset}" );
                Console.WriteLine( $"{greenFg}Green text{reset}" );
                Console.WriteLine( $"{yellowFg}Yellow text{reset}" );
                Console.WriteLine( $"{blueFg}Blue text{reset}" );
                Console.WriteLine( $"{magentaFg}Magenta text{reset}" );
                Console.WriteLine( $"{cyanFg}Cyan text{reset}" );
                Console.WriteLine( $"{whiteFg}White text{reset}" );

                // Print examples for background colors
                Console.WriteLine( $"{blackBg}Text on black background{reset}" );
                Console.WriteLine( $"{redBg}Text on red background{reset}" );
                Console.WriteLine( $"{greenBg}Text on green background{reset}" );
                Console.WriteLine( $"{yellowBg}Text on yellow background{reset}" );
                Console.WriteLine( $"{blueBg}Text on blue background{reset}" );
                Console.WriteLine( $"{magentaBg}Text on magenta background{reset}" );
                Console.WriteLine( $"{cyanBg}Text on cyan background{reset}" );
                Console.WriteLine( $"{whiteBg}Text on white background{reset}" );

                // Combined example
                Console.WriteLine( $"{underline}{bold}{redFg}{greenBg}Underlined, bold, red text on green background{reset}" );


                var sc =Logic.Controller.ScreenController

                Console.WriteLine(  );


                Console.ReadLine( );
        }
}