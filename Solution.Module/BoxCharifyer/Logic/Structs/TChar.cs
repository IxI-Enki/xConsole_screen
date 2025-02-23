using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Structs;

public static class TCharExtensions
{
        private static readonly char[] _allChars = [ .. "╵ ╷ ╶ ╴ ╹ ╻ ╺ ╸ │ ┃ ║ ╽ ╿ ╎ ╏ ┆ ┇ ┊ ┋ ─ ━ ═ ╾ ╼ ╌ ╍ ┄ ┅ ┈ ┉ ╭ ╮ ┌ ┐ ╰ ╯ └ ┘ ┍ ┑ ┎ ┒ ┕ ┙ ┖ ┚ ┏ ┓ ┗ ┛ ╒ ╕ ╓ ╖ ╘ ╛ ╙ ╜ ╔ ╗ ╚ ╝ ├ ┤ ┝ ┥ ┟ ┧ ┞ ┦ ┢ ┪ ┡ ┩ ┠ ┨ ┣ ┫ ╞ ╡ ╟ ╢ ╠ ╣ ┬ ┴ ┭ ┮ ┰ ┵ ┶ ┸ ┯ ┱ ┲ ┷ ┹ ┺ ┳ ┻ ╤ ╥ ╧ ╨ ╦  ╩ ┼ ┽ ┾ ╀ ╁ ┿ ╂ ╪ ╫ ╃ ╄ ╅ ╆ ╇ ╈ ╉ ╊ ╋ ╬" ];

        public static char[] AllBoxChars => _allChars;

        public static void PrintAllBoxChars( )
        {
                Console.OutputEncoding = Encoding.UTF8;

                foreach(char c in _allChars)
                {
                        Console.Write ( c + " ");
                }
        }
}
public struct TChar
{


        public char Char;

        public static void PrintAllBoxChars( ) => Logic.Structs.TCharExtensions.PrintAllBoxChars( );
}
